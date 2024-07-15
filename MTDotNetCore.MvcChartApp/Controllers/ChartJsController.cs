using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcChartApp.Models.ChartJs;

namespace MTDotNetCore.MvcChartApp.Controllers;

public class ChartJsController : Controller
{
    public IActionResult ExampleBarChart()
    {
        ExampleBarChartModel model = new ExampleBarChartModel
        {
            Label = "No of Votes",
            LabelList = new List<string> { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" },
            Data = new List<int> { 12, 19, 3, 5, 2, 3 }
        };

        return View(model);
    }

    public IActionResult BorderRadiusBarChart()
    {
        return View();
    }

    public IActionResult InterpolationLineChart()
    {
        InterpolationLineChartModel model = new InterpolationLineChartModel()
        {
            Title = "Chart.js Line Chart - Cubic interpolation mode",
            Label = "Cubic interpolation (monotone)",
            DataPoints = new List<int> { 0, 20, 20, 60, 60, 120, 180, 120, 125, 105, 110, 170 }
        };

        return View(model);
    }
}
