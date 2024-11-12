using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTDotNetCore.PaginationAPI.DB;
using MTDotNetCore.PaginationAPI.Models;

namespace MTDotNetCore.PaginationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _db.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        [HttpGet("pageNo/{pageNo}/pageSize/{pageSize}")]
        public IActionResult GetBlogs(int pageNo, int pageSize)
        {
            int rowCount = _db.Blogs.Count();
            int pageCount = rowCount / pageSize;
            if (rowCount % pageSize > 0)
            {
                pageCount++;
            }

            if (pageNo > pageCount)
            {
                return BadRequest(new { Message = "Invalid Page No." });
            }

            var lst = _db
                .Blogs.OrderByDescending(x => x.BlogId)
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            BlogResponseModel responseModel = new BlogResponseModel()
            {
                Data = lst,
                PageNo = pageNo,
                PageSize = pageSize,
                PageCount = pageCount,
            };

            return Ok(responseModel);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel model)
        {
            var entry = _db.Blogs.Add(model);
            var createdBlog = entry.Entity;

            int result = _db.SaveChanges();

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
            var item = _db.Blogs.FirstOrDefault(b => b.BlogId == id);
            if (item is null)
            {
                return NotFound($"No data found for the blog Id: {id}");
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        [ActionName("Update")]
        public IActionResult UpdateBlog(int id, BlogModel model)
        {
            var item = _db.Blogs.FirstOrDefault(b => b.BlogId == id);
            if (item is null)
            {
                return NotFound($"Not Found the blog with Id: {id}");
            }

            item.BlogTitle = model.BlogTitle;
            item.BlogAuthor = model.BlogAuthor;
            item.BlogContent = model.BlogContent;

            int result = _db.SaveChanges();
            string message = result > 0 ? "Update Successful." : "Update Failed.";

            return Ok(message);
        }

        [HttpDelete("{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBlogAsync(int id)
        {
            var item = _db.Blogs.FirstOrDefault(b => b.BlogId == id);
            if (item is null)
            {
                return NotFound($"Not found the blog with Id: {id}");
            }

            _db.Blogs.Remove(item);
            int result = await _db.SaveChangesAsync();

            if (result <= 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Failed.");

            return Ok("Delete Successful");
        }
    }
}
