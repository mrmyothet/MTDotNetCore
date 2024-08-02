using System.Net;
using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.PaginationAPI.DB;
using MTDotNetCore.PaginationAPI.Models;

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

        [HttpPost]
        public IActionResult CreateBlog(BlogModel model)
        {
            var entry = _context.Blogs.Add(model);
            var createdBlog = entry.Entity;

            int result = _context.SaveChanges();

            if (result <= 0)
                return BadRequest();

            return Created(
                new Uri($"/api/blogs/{createdBlog.BlogId}", UriKind.Relative),
                createdBlog
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(b => b.BlogId == id);
            return Ok(item);
        }
    }
}
