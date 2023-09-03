using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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
        private ILogger _logger;

        public ProductsController(DatabaseContext context, IMapper mapper, ILogger<ProductsController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _context.Products.Include(p => p.Category).ToList();
                var result = _mapper.Map<List<GetProductDTO>>(products);
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something Went Wront in the {nameof(GetProducts)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProduct(
            [FromHeader(Name = "Authorization")] string authorization, 
            [FromBody] CreateProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            var createdProduct = _context.Products.Add(product).Entity;
            _context.SaveChanges();

            return Ok(createdProduct.Id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut()]
        public IActionResult UpdateProduct(
            [FromHeader(Name = "Authorization")] string authorization, 
            [FromBody] UpdateProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct([FromHeader(Name = "Authorization")] string authorization, int id)
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
