using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organic_Shop_BackEnd.Database;
using Organic_Shop_BackEnd.DTO;
using Organic_Shop_BackEnd.Model;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace Organic_Shop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private DatabaseContext _context;
        private ILogger _logger;

        public ShoppingCartController(DatabaseContext context, IMapper mapper, ILogger<ProductsController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCart(
            [FromHeader(Name = "Authorization")] string authorization, 
            [FromHeader(Name = "Authentication")] string token)
        {
            var userName = GetValueFromToken(token, propertyName: "name");

            var cart = _context.ShoppingCarts
                .Include(sc => sc.User)
                .Include(sc => sc.ShoppingCartItems)
                .Include(sc => sc.ShoppingCartItems).ThenInclude(sci => sci.Product).ThenInclude(p => p.Category)
                .Where(sc => sc.User.Email == userName)
                .FirstOrDefault();

            if (cart is null)
            {
                var userId = GetValueFromToken(token, propertyName: "userId");
                cart = CreateCartInDb(userId);
            }

            return Ok(_mapper.Map<ShoppingCartDTO>(cart));
        }

 

        [Authorize(Roles = "Admin, User")]
        [HttpPost("AddProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AddToCart(
            [FromHeader(Name = "Authorization")] string authorization,
            [FromHeader(Name = "Authentication")] string token,
            [FromBody] int productId)
        {
            var userId = GetValueFromToken(token, propertyName: "userId");
            var cart = _context.ShoppingCarts
                .Include(sc => sc.User)
                .Include(sc => sc.ShoppingCartItems)
                .Where(sc => sc.User.Id == userId)
                .FirstOrDefault();

            if (cart is null) cart = CreateCartInDb(userId);
            
            var product = _context.ShoppingCartItems
                .Where(sci => sci.ProductId == productId && sci.ShoppingCartId == cart.Id)
                .FirstOrDefault();

            if (product is null)
                cart.ShoppingCartItems.Add(new ShoppingCartItem()
                {
                    ProductId = productId,
                    Quantity = 1,
                    ShoppingCartId = cart.Id
                });
            else product.Quantity += 1;

            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("ReplaceAnonCartToUserCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ReplaceAnonCartToUserCart(
            [FromHeader(Name = "Authentication")] string token,
            [FromHeader(Name = "localStorageCartId")] string localStorageCartId)
        {
            var anonShoppingCart = _context.AnonShoppingCarts
                .Include(asc => asc.AnonShoppingCartItems)
                .Where(asc => asc.LocalCartId == localStorageCartId)
                .FirstOrDefault();

            if (anonShoppingCart is null) return NotFound();

            if (anonShoppingCart.AnonShoppingCartItems.Count == 0)
            {
                _context.Remove(anonShoppingCart);
                return Ok();
            }

            var userId = GetValueFromToken(token, propertyName: "userId");

            //var userCart = CreateCartInDb(userId);

            var userCart = _context.ShoppingCarts
                .Include(sc => sc.ShoppingCartItems)
                .Where(sc => sc.UserId == userId)
                .FirstOrDefault();

            if (userCart is null)
            {
                userCart = CreateCartInDb(userId);
                userCart.ShoppingCartItems = new List<ShoppingCartItem>();
            }

            userCart.ShoppingCartItems.Clear();

            foreach (var anonCartItem in anonShoppingCart.AnonShoppingCartItems)
                userCart.ShoppingCartItems.Add(new ShoppingCartItem
                {
                    Quantity = anonCartItem.Quantity,
                    ProductId = anonCartItem.ProductId,
                });

            _context.Remove(anonShoppingCart);
            _context.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{productId:int}", Name = "RemoveProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult RemoveFromCart(
            [FromHeader(Name = "Authorization")] string authorization,
            [FromHeader(Name = "Authentication")] string token, 
            int productId)
        {
            var userId = GetValueFromToken(token, propertyName: "userId");
            var cart = _context.ShoppingCarts.Include(sc => sc.User).Where(sc => sc.User.Id == userId).FirstOrDefault();

            if (cart is null) return BadRequest("Shopping cart is empty");

            var product = _context.ShoppingCartItems
                .Where(sci => sci.ProductId == productId && sci.ShoppingCartId == cart.Id)
                .FirstOrDefault();

            if (product is null) return BadRequest("Product doesn't exist in shopping cart");

            product.Quantity -= 1;

            if (product.Quantity == 0)
                _context.ShoppingCartItems.Remove(product);

            _context.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("ClearCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ClearCart(
            [FromHeader(Name = "Authorization")] string authorization,
            [FromHeader(Name = "Authentication")] string token)
        {
            var userId = GetValueFromToken(token, "userId");
            var cart = _context.ShoppingCarts
                .Include(sc => sc.User)
                .Include(sc => sc.ShoppingCartItems)
                .Where(sc => sc.User.Id == userId)
                .FirstOrDefault();

            if (cart is null) return BadRequest("Shopping cart already is empty");

            cart.ShoppingCartItems.Clear();
            _context.SaveChanges();
            return Ok();
        }

        private string GetValueFromToken(string token, string propertyName)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var tokenValue = jwtSecurityToken.Claims.First(claim => claim.Type == propertyName).Value;
            return tokenValue;
        }

        private ShoppingCart CreateCartInDb(string userId)
        {
            var shoppingCart = new ShoppingCart
            {
                DateCreated = DateTimeOffset.Now.ToUnixTimeSeconds(),
                UserId = userId,
                ShoppingCartItems = new List<ShoppingCartItem>(),
            };

            var entityShoppingCart = _context.ShoppingCarts.Add(shoppingCart);
            _context.SaveChanges();
            return entityShoppingCart.Entity;
        }
    }
}
