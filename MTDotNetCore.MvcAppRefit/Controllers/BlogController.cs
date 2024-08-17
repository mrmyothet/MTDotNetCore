using Microsoft.AspNetCore.Mvc;

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
    }
}
