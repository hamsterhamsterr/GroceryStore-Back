using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organic_Shop_BackEnd.Database;
using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.Include(p => p.Category).ToList());
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var response = _context.Products
                                .Include(p => p.Category)
                                .Where(p => p.Id == id)
                                .FirstOrDefault();

            if (response is null)
                return NotFound();
            
            return Ok(response);
        }

        //[HttpPost]
        //public IActionResult CreateProduct([FromBody] Product product)
        //{
        //    _context.Products.Add(product);
        //    return Ok();
        //}
    }
}
