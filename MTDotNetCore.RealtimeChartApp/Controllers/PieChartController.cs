using Microsoft.AspNetCore.Mvc;

namespace MTDotNetCore.RealtimeChartApp.Controllers
{
    public class PieChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
