using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcApp2.Models;
using Newtonsoft.Json;

namespace MTDotNetCore.MvcApp2.Controllers;

public class BlogController : Controller
{
    private readonly HttpClient _httpClient;

    public BlogController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IActionResult> IndexAsync(int pageNo = 1, int pageSize = 10)
    {
        BlogResponseModel model = new BlogResponseModel();

        var response = await _httpClient.GetAsync($"api/blog/{pageNo}/{pageSize}");

        if (!response.IsSuccessStatusCode)
            return View("Error");

        string jsonStr = await response.Content.ReadAsStringAsync();
        model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr)!;

        return View(model);
    }
}
