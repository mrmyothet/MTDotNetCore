﻿using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcChartApp.Models.HighChart;
using static MTDotNetCore.MvcChartApp.Models.HighChart.BasicColumnChartModel;

namespace MTDotNetCore.MvcChartApp.Controllers;

public class HighChartController : Controller
{
    public IActionResult PieChart()
    {
        PieChartModel model = new PieChartModel();
        model.DataList = new List<DataPoint>()
        {
            new DataPoint() { Name = "Water", y = 55.02 },
            new DataPoint() { Name = "Fat", y = 26.71 },
            new DataPoint() { Name = "Carbohydrates", y = 1.09 },
            new DataPoint() { Name = "Protein", y = 15.5 },
            new DataPoint() { Name = "Ash", y = 1.68 },
        };

        return View(model);
    }

    public IActionResult LineChart()
    {
        LineChartModel model = new LineChartModel();
        model.DataList = new List<LineChartData>();
        model.DataList.Add(
            new LineChartData
            {
                name = "Reggane",
                data = { 16.0, 18.2, 23.1, 27.9, 32.2, 36.4, 39.8, 38.4, 35.5, 29.2, 22.0, 17.8 },
            }
        );

        model.DataList.Add(
            new LineChartData
            {
                name = "Tallinn",
                data = { -2.9, -3.6, -0.6, 4.8, 10.2, 14.5, 17.6, 16.5, 12.0, 6.5, 2.0, -0.9 },
            }
        );

        return View(model);
    }

    public IActionResult BasicColumnChart()
    {
        BasicColumnChartModel model = new BasicColumnChartModel();
        model.Countries = new List<string> { "USA", "China", "Brazil", "EU", "Argentina", "India" };

        var corn = new CropData
        {
            name = "Corn",
            data = new int[] { 387749, 280000, 129000, 64300, 54000, 34300 }
        };

        var wheat = new CropData
        {
            name = "Wheat",
            data = new int[] { 45321, 140000, 10000, 140500, 19500, 113500 }
        };

        model.DataList.Add(corn);
        model.DataList.Add(wheat);

        return View(model);
    }
}
