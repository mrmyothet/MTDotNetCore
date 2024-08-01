using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.PaginationAPI.DB;

namespace MTDotNetCore.PaginationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }
    }
}
