using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organic_Shop_BackEnd.Database;
using Organic_Shop_BackEnd.DTO;
using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private DatabaseContext _context;

        public ProductsController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            var result = _mapper.Map<List<GetProductDTO>>(products);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products
                                .Include(p => p.Category)
                                .Where(p => p.Id == id)
                                .FirstOrDefault();

            if (product is null)
                return NotFound();

            var result = _mapper.Map<GetProductDTO>(product);
            
            return Ok(result);
        }

        //[HttpPost]
        //public IActionResult CreateProduct([FromBody] Product product)
        //{
        //    _context.Products.Add(product);
        //    return Ok();
        //}
    }
}
