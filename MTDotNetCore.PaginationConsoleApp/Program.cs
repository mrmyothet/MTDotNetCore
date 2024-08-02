HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:7254") };
string blogEndPoint = "/api/blog";

var response = await _httpClient.GetAsync(blogEndPoint);

if (!response.IsSuccessStatusCode)
    Console.WriteLine("Error in Get Blogs");

Console.WriteLine("Success Status Code");
string jsonString = await response.Content.ReadAsStringAsync();
Console.WriteLine(jsonString);

Console.ReadLine();

public class BlogModel
{
    public int blogId { get; set; }
    public string blogTitle { get; set; }
    public string blogAuthor { get; set; }
    public string blogContent { get; set; }
}
