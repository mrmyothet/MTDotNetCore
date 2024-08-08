using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.PaginationMvc.DB;
using MTDotNetCore.PaginationMvc.Models;

namespace MTDotNetCore.PaginationMvc.Controllers;

public class BlogController : Controller
{
    private readonly AppDbContext _dbContext;

    public BlogController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [ActionName("Index")]
    public IActionResult Index(int pageNo = 1, int pageSize = 10)
    {
        int rowCount = _dbContext.Blogs.Count();

        int pageCount = rowCount / pageSize;
        if (rowCount % pageSize > 0)
            pageCount++;

        //
        if (pageNo > pageCount)
        {
            return View();
        }

        int skippedRows = (pageNo - 1) * pageSize;

        BlogResponseModel model = new BlogResponseModel()
        {
            Data = _dbContext
                .Blogs
                //.OrderByDescending(x => x.BlogId)
                .Skip(skippedRows)
                .Take(pageSize)
                .ToList(),
            PageNo = pageNo,
            PageSize = pageSize,
            PageCount = pageCount
        };

        return View(model);
    }
}
