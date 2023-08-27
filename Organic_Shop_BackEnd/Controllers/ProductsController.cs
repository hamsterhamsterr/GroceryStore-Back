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

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut()]
        public IActionResult UpdateProduct([FromBody] UpdateProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products
                                .Where(p => p.Id == id)
                                .FirstOrDefault();

            if (product is null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}
