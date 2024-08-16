using System.Text;
using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcApp2.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace MTDotNetCore.MvcApp2.Controllers;

public class BlogController : Controller
{
    private readonly HttpClient _httpClient;

    public BlogController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [ActionName("Index")]
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

    [ActionName("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ActionName("Save")]
    public async Task<IActionResult> SaveAsync(BlogModel model)
    {
        string jsonStr = JsonConvert.SerializeObject(model);
        HttpContent content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
        var result = await _httpClient.PostAsync("api/blog", content);
        if (!result.IsSuccessStatusCode)
            return View("Create");

        return Redirect("/Blog");
    }

    [ActionName("Edit")]
    public async Task<IActionResult> Edit(int id)
    {
        BlogModel model = new BlogModel();

        var response = await _httpClient.GetAsync($"api/blog/{id}");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return View("Error");
        }

        if (response.IsSuccessStatusCode && response.Content != null)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
        }

        return View(model);
    }
}
