using Microsoft.EntityFrameworkCore;
using MTDotNetCore.MinimalApi.Db;
using MTDotNetCore.MinimalApi.Models;

namespace MTDotNetCore.MinimalApi.Features.Blog;

public static class BlogService
{
    public static IEndpointRouteBuilder MapBlogs(this IEndpointRouteBuilder app)
    {
        // Get List
        app.MapGet(
            "api/Blog",
            async (AppDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            }
        );

        app.MapGet(
            "api/Blog/{id}",
            (AppDbContext db, int id) =>
            {
                var item = db.Blogs.FirstOrDefault(b => b.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found for Id: " + id);
                }

                return Results.Ok(item);
            }
        );

        // Create
        app.MapPost(
            "api/Blog",
            async (AppDbContext db, BlogModel newBlog) =>
            {
                db.Blogs.Add(newBlog);
                int result = await db.SaveChangesAsync();

                string message = result > 0 ? "Saving Successful." : "Saving Failed.";
                return Results.Ok(message);
            }
        );

        // Update
        app.MapPut(
            "api/Blog/{id}",
            async (AppDbContext db, int id, BlogModel editBlog) =>
            {
                var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found for Id: " + id);
                }

                item.BlogTitle = editBlog.BlogTitle;
                item.BlogAuthor = editBlog.BlogAuthor;
                item.BlogContent = editBlog.BlogContent;
                var result = await db.SaveChangesAsync();

                string message = result > 0 ? "Update Successful." : "Update Failed";
                return Results.Ok(message);
            }
        );

        app.MapDelete(
            "api/Blog/{id}",
            async (AppDbContext db, int id) =>
            {
                var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found for Id: " + id);
                }

                db.Blogs.Remove(item);
                int result = await db.SaveChangesAsync();

                string message = result > 0 ? "Delete Successful." : "Delete Failed.";
                return Results.Ok(message);
            }
        );

        return app;
    }
}
