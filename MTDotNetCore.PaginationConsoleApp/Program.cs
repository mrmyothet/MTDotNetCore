using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:7254") };
string blogEndPoint = "/api/blog";

int NoOfRecords = 395;
for (int i = 0; i < NoOfRecords; i++)
{
    int rowNo = i + 1;
    BlogModel newBlog = new BlogModel()
    {
        blogTitle = "Sample Title " + rowNo,
        blogAuthor = "Sample Author " + rowNo,
        blogContent = "Sample Content " + rowNo
    };

    await CreateBlogPostAsync(_httpClient, newBlog);
}

var response = await _httpClient.GetAsync(blogEndPoint);

if (!response.IsSuccessStatusCode)
    Console.WriteLine("Error in Get Blogs");

Console.WriteLine("Success Status Code");
string jsonString = await response.Content.ReadAsStringAsync();

if (!String.IsNullOrEmpty(jsonString))
{
    List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonString)!;
    Console.WriteLine(lst.Count);
}

Console.ReadLine();

async Task CreateBlogPostAsync(HttpClient httpClient, BlogModel newblog)
{
    string strNewBlog = JsonConvert.SerializeObject(newblog);
    HttpContent content = new StringContent(strNewBlog, Encoding.UTF8, Application.Json);
    var result = await httpClient.PostAsync(blogEndPoint, content);
    if (result.IsSuccessStatusCode)
    {
        string strResponse = await result.Content.ReadAsStringAsync();
        Console.WriteLine(strResponse);
    }
}

public class BlogModel
{
    public int blogId { get; set; }
    public string? blogTitle { get; set; }
    public string? blogAuthor { get; set; }
    public string? blogContent { get; set; }
}
