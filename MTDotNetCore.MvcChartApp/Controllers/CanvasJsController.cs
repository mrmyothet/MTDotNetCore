using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcChartApp.Models.CanvasJs;

namespace MTDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        private readonly ILogger<CanvasJsController> _logger;

        public CanvasJsController(ILogger<CanvasJsController> logger)
        {
            _logger = logger;
        }

        public IActionResult LineChart()
        {
            _logger.LogInformation("CanvasJS - Line Chart.");

            LineChartModel model = new LineChartModel();
            model.DataList = new List<DataPoint>
            {
                new DataPoint() { y = 450 },
                new DataPoint() { y = 414 },
                new DataPoint()
                {
                    y = 520,
                    indexLabel = "\u2191 highest",
                    markerColor = "red",
                    markerType = "triangle"
                },
                new DataPoint() { y = 460 },
                new DataPoint() { y = 450 },
                new DataPoint() { y = 500 },
                new DataPoint() { y = 480 },
                new DataPoint() { y = 480 },
                new DataPoint()
                {
                    y = 410,
                    indexLabel = "\u2193 lowest",
                    markerColor = "DarkSlateGrey",
                    markerType = "cross"
                },
                new DataPoint() { y = 500 },
                new DataPoint() { y = 480 },
                new DataPoint() { y = 510 }
            };

            return View(model);
        }
    }
}
