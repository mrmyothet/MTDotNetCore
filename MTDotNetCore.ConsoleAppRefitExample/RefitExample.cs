using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDotNetCore.ConsoleAppRefitExample;

public class RefitExample
{
    private readonly IBlogApi _blogApi;

    public RefitExample(string applicationUrl)
    {
        _blogApi = RestService.For<IBlogApi>(applicationUrl);
    }

    public async Task ReadAsync()
    {
        var lst = await _blogApi.GetBlogs();
        foreach (var item in lst)
        {
            Console.WriteLine($"Id => {item.BlogId}");
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
            Console.WriteLine("==========");
        }
    }

    public async Task EditAsync(int id)
    {
        try
        {
            var item = await _blogApi.GetBlog(id);

            Console.WriteLine($"Id => {item.BlogId}");
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
            Console.WriteLine("==========");
        }
        catch (Refit.ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task CreateAsync(string title, string author, string content)
    {
        Blog newBlog = new Blog()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content,
        };

        try
        {
            string message = await _blogApi.CreateBlog(newBlog);
            Console.WriteLine(message);
        }
        catch (Refit.ApiException ex)
        {
            Console.WriteLine(ex.Content);
        }
    }
}
