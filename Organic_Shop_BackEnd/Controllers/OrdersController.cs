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
        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var orders = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ThenInclude(p => p.Category)
                .ToList();

            var ordersDTO = new List<GetOrderDTO>();
            foreach (var order in orders)
                ordersDTO.Add(_mapper.Map<GetOrderDTO>(order));

            return Ok(ordersDTO);
        }

        //[Authorize()]
        [HttpGet("GetOrdersByUser")]
        public IActionResult GetOrdersByUser([FromHeader(Name = "Authentication")] string token)
        {
            var userId = GetValueFromToken(token, propertyName: "userId");
            var orders = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ThenInclude(p => p.Category)
                .Where(o => o.UserId == userId)
                .ToList();

            var ordersDTO = new List<GetOrderDTO>();
            foreach (var order in orders)
                ordersDTO.Add(_mapper.Map<GetOrderDTO>(order));

            return Ok(ordersDTO);
        }

        //[Authorize()]
        [HttpGet("{orderId:int}")]
        public IActionResult GetOrderByUser([FromHeader(Name = "Authentication")] string token, int orderId)
        {
            var userId = GetValueFromToken(token, propertyName: "userId");
            var isAdmin = IsAdmin(token);

            var order = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ThenInclude(p => p.Category)
                .Where(o => (isAdmin && o.Id == orderId) || (o.UserId == userId && o.Id == orderId)).FirstOrDefault();

            if (order == null) return NotFound();

            return Ok(_mapper.Map<GetOrderDTO>(order));
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

            var orderEntity = _context.Add(order);
            _context.SaveChanges();
            // Creates id after save changes.
            return Ok(orderEntity.Entity.Id);
        }

        private string GetValueFromToken(string token, string propertyName)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var tokenValue = jwtSecurityToken.Claims.First(claim => claim.Type == propertyName).Value;
            return tokenValue;
        }

        private bool IsAdmin(string token)
        {
            var role = GetValueFromToken(token, "role");
            if (role == "Admin") return true;
            return false;
        }
    }
}
