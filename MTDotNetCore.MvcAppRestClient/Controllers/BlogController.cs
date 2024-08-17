using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcAppRestClient.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MTDotNetCore.MvcAppRestClient.Controllers
{
    public class BlogController : Controller
    {
        private readonly RestClient _restClient;

        public BlogController(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
        {
            string resource = $"/api/blog/{pageNo}/{pageSize}";

            RestRequest restRequest = new RestRequest(resource, Method.Get);
            var response = await _restClient.ExecuteAsync(restRequest);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Error");

            string jsonString = response.Content!;
            BlogResponseModel model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonString)!;

            return View(model);
        }
    }
}
