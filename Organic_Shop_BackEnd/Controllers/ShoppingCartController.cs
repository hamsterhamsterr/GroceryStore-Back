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

        //[Authorize]
        [HttpGet]
        public IActionResult GetCart([FromHeader(Name = "Authentication")] string token)
        {
            var userName = GetValueFromToken(token, propertyName: "name");

            var cart = _context.ShoppingCarts
                .Include(sc => sc.User)
                .Include(sc => sc.ShoppingCartItems)
                .Include(sc => sc.ShoppingCartItems).ThenInclude(sci => sci.Product).ThenInclude(p => p.Category)
                .Where(sc => sc.User.Email == userName)
                .FirstOrDefault();

            if (cart is null) return NotFound();

            return Ok(_mapper.Map<ShoppingCartDTO>(cart));
        }

        //[Authorize]
        [HttpPost]
        public IActionResult AddToCart([FromHeader(Name = "Authentication")] string token,
                                       [FromBody] int productId)
        {
            var userId = GetValueFromToken(token, propertyName: "userId");
            var cart = _context.ShoppingCarts.Include(sc => sc.User).Where(sc => sc.User.Id == userId).FirstOrDefault();

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
