using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic_Shop_BackEnd.Database;
using Organic_Shop_BackEnd.DTO;
using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private DatabaseContext _context;

        public CategoriesController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            var result = _mapper.Map<List<GetCategoryDTO>>(categories);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (category is null)
                return NotFound();

            var result = _mapper.Map<GetCategoryDTO>(category);
            return Ok(result);
        }

        [HttpGet("{nameIdentificator}", Name = "GetCategoryByNameIdentificator")]
        public IActionResult GetCategoryByNameIdentificator(string nameIdentificator)
        {
            var category = _context.Categories
                .Where(c => c.NameIdentificator == nameIdentificator)
                .FirstOrDefault();

            if (category is null)
                return NotFound();

            var result = _mapper.Map<GetCategoryDTO>(category);
            return Ok(result);
        }
    }
}
