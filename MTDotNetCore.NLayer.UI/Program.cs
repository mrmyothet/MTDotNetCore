// See https://aka.ms/new-console-template for more information
using MTDotNetCore.NLayer.BusinessLogic.Services;
using MTDotNetCore.NLayer.DataAccess.Models;

Console.WriteLine("Hello, World!");

BL_Blog bl_blog = new BL_Blog();

BlogModel newBlog = new BlogModel() {  
    BlogTitle = "sample Title", 
    BlogAuthor = "sample Author", 
    BlogContent="sample content"
};
bl_blog.CreateBlog(newBlog);