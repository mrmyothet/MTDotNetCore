﻿using Refit;
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

    [Put("/api/blog/{id}")]
    Task<string> UpdateBlog(int id, Blog updateBlog);

    [Patch("/api/blog/{id}")]
    Task<string> PatchBlog(int id, Blog patchBlog);

    [Delete("/api/blog/{id}")]
    Task<string> DeleteBlog(int id);
}
