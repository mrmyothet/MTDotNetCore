using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.PaginationMvc.DB;

namespace MTDotNetCore.PaginationMvc.Controllers;

public class BlogController : Controller
{
    private readonly AppDbContext _dbContext;

    public BlogController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var lst = _dbContext.Blogs.ToList();
        ViewBag.Count = lst.Count();
        return View();
    }
}
