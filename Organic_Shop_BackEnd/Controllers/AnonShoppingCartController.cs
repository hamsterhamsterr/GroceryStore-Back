using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organic_Shop_BackEnd.Database;
using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnonShoppingCartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private DatabaseContext _context;
        private ILogger _logger;

        public AnonShoppingCartController(DatabaseContext context, IMapper mapper, ILogger<ProductsController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAnonCart([FromHeader] string localStorageCartId)
        {
            var cart = GetCart(localStorageCartId);

            if (cart is null) cart = CreateCart(localStorageCartId);

            return Ok(cart);
        }

        [HttpPost("AddProductToCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddToAnonCart(
            [FromHeader] string localStorageCartId,
            [FromBody] int productId)
        {
            var cart = _context.AnonShoppingCarts
                .Include(asc => asc.AnonShoppingCartItems)
                .Where(asc => asc.LocalCartId == localStorageCartId)
                .FirstOrDefault();

            if (cart is null) return NotFound();
            
            var product = _context.AnonShoppingCartItems
                .Where(asci => asci.ProductId == productId && asci.AnonShoppingCartId == cart.Id)
                .FirstOrDefault();

            if (product is null)
                cart.AnonShoppingCartItems.Add(new AnonShoppingCartItem()
                {
                    ProductId = productId,
                    Quantity = 1,
                    AnonShoppingCartId = cart.Id
                });
            else product.Quantity += 1;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{productId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RemoveFromAnonCart(
            [FromHeader] string localStorageCartId,
            int productId)
        {
            var cart = _context.AnonShoppingCarts
                .Include(asc => asc.AnonShoppingCartItems)
                .Where(asc => asc.LocalCartId == localStorageCartId)
                .FirstOrDefault();

            if (cart is null) return NotFound();

            var product = _context.AnonShoppingCartItems
               .Where(asci => asci.ProductId == productId && asci.AnonShoppingCartId == cart.Id)
               .FirstOrDefault();

            if (product is null) return BadRequest("Product doesn't exist in shopping cart");

            product.Quantity -= 1;

            if (product.Quantity == 0)
                _context.AnonShoppingCartItems.Remove(product);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("ClearCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ClearAnonCart([FromHeader] string localStorageCartId)
        {
            var cart = _context.AnonShoppingCarts
                .Include(asc => asc.AnonShoppingCartItems)
                .Where(asc => asc.LocalCartId == localStorageCartId)
                .FirstOrDefault();

            if (cart is null) return BadRequest("Shopping cart already is empty");

            cart.AnonShoppingCartItems.Clear();
            _context.SaveChanges();
            return Ok();
        }

        private AnonShoppingCart? GetCart(string localStorageCartId)
        {
            var cart = _context.AnonShoppingCarts
                .Include(asc => asc.AnonShoppingCartItems)
                .ThenInclude(asci => asci.Product)
                .ThenInclude(p => p.Category)
                .Where(asc => asc.LocalCartId == localStorageCartId)
                .FirstOrDefault();

            if (cart is null) return null;
            return cart;
        }

        private AnonShoppingCart CreateCart(string localStorageCartId)
        {
            var shoppingCart = new AnonShoppingCart
            {
                DateCreated = DateTimeOffset.Now.ToUnixTimeSeconds(),
                LocalCartId = localStorageCartId,
                AnonShoppingCartItems = new List<AnonShoppingCartItem>()
            };

            var entityCart = _context.AnonShoppingCarts.Add(shoppingCart);
            _context.SaveChanges();
            return entityCart.Entity;
        }
    }
}
