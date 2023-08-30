using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organic_Shop_BackEnd.Database;
using Organic_Shop_BackEnd.DTO;
using Organic_Shop_BackEnd.Model;
using System.IdentityModel.Tokens.Jwt;

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
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var userName = jwtSecurityToken.Claims.First(claim => claim.Type == "name").Value;

            var cart = _context.ShoppingCarts
                .Include(sc => sc.User)
                .Include(sc => sc.ShoppingCartItems)
                .Include(sc => sc.ShoppingCartItems).ThenInclude(sci => sci.Product).ThenInclude(p => p.Category)
                .Where(sc => sc.User.Email == userName)
                .FirstOrDefault();

            if (cart is null) return NotFound();

            return Ok(_mapper.Map<ShoppingCartDTO>(cart));
        }
    }
}
