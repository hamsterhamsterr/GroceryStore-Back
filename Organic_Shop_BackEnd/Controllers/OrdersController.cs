using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic_Shop_BackEnd.Database;
using Organic_Shop_BackEnd.DTO;
using Organic_Shop_BackEnd.Model;
using System.IdentityModel.Tokens.Jwt;

namespace Organic_Shop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private DatabaseContext _context;
        private ILogger _logger;

        public OrdersController(DatabaseContext context, IMapper mapper, ILogger<ProductsController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult PlaceOrder(
            [FromHeader(Name = "Authentication")] string token, 
            [FromBody] CreateOrderDTO orderDTO)
        {
            var userId = GetValueFromToken(token, propertyName: "userId");
            var order = _mapper.Map<Order>(orderDTO);
            order.UserId = userId;
            order.datePlaced = DateTimeOffset.Now.ToUnixTimeSeconds();

            _context.Add(order);
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
    }
}
