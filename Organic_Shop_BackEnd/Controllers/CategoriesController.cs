using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organic_Shop_BackEnd.Database;
using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToList();
        }
    }
}
