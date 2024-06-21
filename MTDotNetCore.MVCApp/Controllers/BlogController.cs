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
            List<BlogModel> lst = await _db.Blogs.ToListAsync();
            return View(lst);
        }
    }
}
