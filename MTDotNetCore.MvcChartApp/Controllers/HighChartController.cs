using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcChartApp.Models.HighChart;

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
}
