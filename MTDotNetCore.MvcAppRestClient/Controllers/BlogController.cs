using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcAppRestClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            RestRequest restRequest = new RestRequest($"/api/blog/{pageNo}/{pageSize}", Method.Get);
            var response = await _restClient.ExecuteAsync(restRequest);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Error");

            string jsonString = response.Content!;
            BlogResponseModel model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonString)!;

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save(BlogModel model)
        {
            string jsonString = JsonConvert.SerializeObject(model);

            RestRequest restRequest = new RestRequest("/api/blog", Method.Post);
            restRequest.AddJsonBody(jsonString);
            await _restClient.ExecuteAsync(restRequest);

            return Redirect("/Blog");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            RestRequest restRquest = new RestRequest($"/api/blog/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync(restRquest);
            if (!response.IsSuccessStatusCode)
                return Redirect("Error");

            string jsonString = response.Content!;
            BlogModel model = JsonConvert.DeserializeObject<BlogModel>(jsonString)!;

            return View(model);
        }

        [ActionName("Update")]
        public async Task<IActionResult> Update(int id, BlogModel model)
        {
            RestRequest restRequest = new RestRequest($"/api/blog/{id}", Method.Put);
            restRequest.AddJsonBody(model);
            var response = await _restClient.ExecuteAsync(restRequest);
            if (!response.IsSuccessStatusCode)
                return Redirect("Error");

            return Redirect("/blog");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            RestRequest restRequest = new RestRequest($"/api/blog/{id}", Method.Delete);
            var response = await _restClient.ExecuteAsync(restRequest);
            if (!response.IsSuccessStatusCode)
                return Redirect("Error");

            return Redirect("/blog");
        }
    }
}
