using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:7233/api/blog");

if (response.IsSuccessStatusCode)
{
    string jsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(jsonStr);

    List<BlogObject> lst = JsonConvert.DeserializeObject<List<BlogObject>>(jsonStr)!;
    foreach (var item in lst)
    {
        Console.WriteLine(JsonConvert.SerializeObject(item));

        Console.WriteLine($"Title => {item.BlogTitle}");
        Console.WriteLine($"Author => {item.BlogAuthor}");
        Console.WriteLine($"Content => {item.BlogContent}");
    }
}

Console.ReadLine();


public class BlogObject
{
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}
