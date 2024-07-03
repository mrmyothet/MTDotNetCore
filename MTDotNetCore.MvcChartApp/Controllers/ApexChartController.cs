﻿using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcChartApp.Models;

namespace MTDotNetCore.MvcChartApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult SimplePieChart()
        {
            PieChartModel model = new PieChartModel();
            model.Series = new List<int> { 44, 55, 13, 43, 22 };
            model.Labels = new List<string>() { "Team A", "Team B", "Team C", "Team D", "Team E" };

            return View(model);
        }
    }
}
