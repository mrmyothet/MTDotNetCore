﻿using Microsoft.AspNetCore.Mvc;
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
        return View();
    }
}