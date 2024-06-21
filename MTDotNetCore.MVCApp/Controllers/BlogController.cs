using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTDotNetCore.MVCApp.Db;
using MTDotNetCore.MVCApp.Models;

namespace MTDotNetCore.MVCApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<BlogModel> lst = await _db.Blogs.OrderByDescending(x => x.BlogId).ToListAsync();
            return View(lst);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save(BlogModel blog)
        {
            await _db.Blogs.AddAsync(blog);
            var result = await _db.SaveChangesAsync();
            if (result > 0)
            {
                return Redirect("/Blog");
            }

            return View("BlogCreate");
        }
    }
}
