using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MTDotNetCore.ConsoleAppRestClientExamples;

internal class RestClientExample
{
    private readonly RestClient _restClient = new RestClient(new Uri("https://localhost:7233"));
    private readonly string _blogEndpoint = "/api/blog";

    public async Task RunAsync()
    {
        //await ReadAsync();

        //await CreateAsync("Title", "Author", "Content");
        //await EditAsync(4016);

        //await UpdateAsync(4016, "Updated Title", "Updated Author", "Updated Content");
        //await EditAsync(4016);

        //await PatchAsync(4016, "", "Update Author again", "");
        //await EditAsync(4016);

        //await CreateAsync("Title", "Author", "Content");
        //await EditAsync(4017);

        //await DeleteAsync(4017);
        await EditAsync(4017);
    }

    private async Task ReadAsync()
    {
        //RestRequest request = new RestRequest(_blogEndpoint);
        //var response = await _restClient.GetAsync(request);

        RestRequest request = new RestRequest(_blogEndpoint, Method.Get);
        var response = await _restClient.ExecuteAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;

            List<BlogObject> lst = JsonConvert.DeserializeObject<List<BlogObject>>(jsonStr)!;
            foreach (var item in lst)
            {
                //Console.WriteLine(JsonConvert.SerializeObject(item));

                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                await Console.Out.WriteLineAsync("==========");
            }
        }
    }

    private async Task EditAsync(int id)
    {
        var item = await FindByIdAsync(id);

        if (item is null)
        {
            await Console.Out.WriteLineAsync("Data Not Found");
            return;
        }

        Console.WriteLine(JsonConvert.SerializeObject(item));

        Console.WriteLine($"Title => {item.BlogTitle}");
        Console.WriteLine($"Author => {item.BlogAuthor}");
        Console.WriteLine($"Content => {item.BlogContent}");
    }

    private async Task DeleteAsync(int id)
    {
        var item = await FindByIdAsync(id);

        if (item is null)
        {
            await Console.Out.WriteLineAsync($"Data Not Found for the Id:{id}");
            return;
        }

        RestRequest request = new RestRequest($"{_blogEndpoint}/{id}", Method.Delete);
        var response = await _restClient.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var message = response.Content!;
            Console.WriteLine(message);
            // other process 
            // continue ...
        }
        else
        {
            var message = response.Content!;
            Console.WriteLine(message);
            // error message 
            // break
        }
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        BlogObject objBlog = new BlogObject()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        RestRequest request = new RestRequest(_blogEndpoint, Method.Post);
        request.AddJsonBody(objBlog);

        var response = await _restClient.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        BlogObject objBlog = new BlogObject()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        RestRequest request = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
        request.AddJsonBody(objBlog);

        var response = await _restClient.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task PatchAsync(int id, string title, string author, string content)
    {
        BlogObject objBlog = new BlogObject()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        RestRequest request = new RestRequest($"{_blogEndpoint}/{id}", Method.Patch);
        request.AddJsonBody(objBlog);

        var response = await _restClient.PatchAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task<BlogObject?> FindByIdAsync(int id)
    {
        RestRequest request = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
        var response = await _restClient.GetAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;

            BlogObject item = JsonConvert.DeserializeObject<BlogObject>(jsonStr)!;
            return item;
        }

        return null;
    }
}
