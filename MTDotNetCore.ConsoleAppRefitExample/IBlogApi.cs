using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDotNetCore.ConsoleAppRefitExample;

public  interface IBlogApi
{
    [Get("/api/blog")]
    Task<List<Blog>> GetBlogs();

    [Get("/api/blog/{id}")]
    Task<Blog> GetBlog(int id);

    [Post("/api/blog")]
    Task<string> CreateBlog(Blog newBlog);
}
