using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDotNetCore.ConsoleAppRefitExample;

public class RefitExample
{
    private readonly IBlogApi _blogApi = RestService.For<IBlogApi>("https://localhost:7289");

    public async Task RunAsync()
    {
        await ReadAsync();
    }

    private async Task ReadAsync()
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

}
