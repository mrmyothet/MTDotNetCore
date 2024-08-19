using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcAppRefit.Models;

namespace MTDotNetCore.MvcAppRefit.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogApi _blogApi;

        public BlogController(IBlogApi blogApi)
        {
            _blogApi = blogApi;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index(int pageNo = 1, int PageSize = 10)
        {
            var model = await _blogApi.GetBlogs(pageNo, PageSize);

            return View(model);
        }

        [ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [ActionName("Save")]
        public async Task<IActionResult> Save(BlogModel model)
        {
            var response = await _blogApi.CreateBlog(model);

            return Redirect("/blog");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _blogApi.GetBlog(id);

            return View(model);
        }

        [ActionName("Update")]
        public async Task<IActionResult> Update(int id, BlogModel model)
        {
            var response = await _blogApi.UpdateBlog(id, model);

            return Redirect("/blog");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _blogApi.DeleteBlog(id);

            return Redirect("/blog");
        }
    }
}
