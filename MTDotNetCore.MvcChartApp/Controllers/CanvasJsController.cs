using Microsoft.AspNetCore.Mvc;

namespace MTDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult LineChart()
        {
            return View();
        }
    }
}
