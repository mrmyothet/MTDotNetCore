using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTDotNetCore.MVCAppAjax.Db;
using MTDotNetCore.MVCAppAjax.Models;

namespace MTDotNetCore.MVCAppAjax.Controllers;

public class BlogController : Controller
{
    private readonly AppDbContext _db;

    public BlogController(AppDbContext db)
    {
        _db = db;
    }

    [ActionName("Index")]
    public async Task<IActionResult> BlogIndex()
    {
        List<BlogModel> lst = await _db
            .Blogs.AsNoTracking()
            .OrderByDescending(x => x.BlogId)
            .ToListAsync();

        return View("BlogIndex", lst);
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

        var message = new MessageModel()
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Saving Successful." : "Saving Failed.",
        };

        return Json(message);
    }

    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> BlogEdit(int id)
    {
        var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);

        if (item is null)
        {
            return Redirect("/Blog");
        }

        return View("BlogEdit", item);
    }

    [HttpPost]
    [ActionName("Update")]
    public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
    {
        var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);
        if (item is null)
        {
            return Redirect("/Blog");
        }

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        _db.Entry(item).State = EntityState.Modified;

        await _db.SaveChangesAsync();

        return Redirect("/Blog");
    }

    [ActionName("Delete")]
    public async Task<IActionResult> BlogDelete(int id)
    {
        var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);
        if (item is null)
        {
            return Redirect("/Blog");
        }

        _db.Blogs.Remove(item);
        await _db.SaveChangesAsync();

        return Redirect("/Blog");
    }
}
