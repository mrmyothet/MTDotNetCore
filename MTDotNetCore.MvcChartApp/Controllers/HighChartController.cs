using Microsoft.AspNetCore.Mvc;

namespace MTDotNetCore.MvcChartApp.Controllers
{
    public class HighChartController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }
    }
}
