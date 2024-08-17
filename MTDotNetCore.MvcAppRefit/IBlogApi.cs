using MTDotNetCore.MvcAppRefit.Models;
using Refit;

namespace MTDotNetCore.MvcAppRefit;

public interface IBlogApi
{
    [Get("/api/blog")]
    Task<List<BlogModel>> GetBlogs();

    [Get("/api/blog/{pageNo}/{pageSize}")]
    Task<BlogResponseModel> GetBlogs(int pageNo, int PageSize);

    [Get("/api/blog/{id}")]
    Task<BlogModel> GetBlog(int id);

    [Post("/api/blog")]
    Task<string> CreateBlog(BlogModel newBlog);

    [Put("/api/blog/{id}")]
    Task<string> UpdateBlog(int id, BlogModel updateBlog);

    [Patch("/api/blog/{id}")]
    Task<string> PatchBlog(int id, BlogModel patchBlog);

    [Delete("/api/blog/{id}")]
    Task<string> DeleteBlog(int id);
}
