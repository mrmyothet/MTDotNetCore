using System.Globalization;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.MvcChartApp.Models.CanvasJs;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MTDotNetCore.MvcChartApp.Controllers;

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

    public IActionResult MultiSeriesAreaChart()
    {
        SerieArea Received = new SerieArea()
        {
            name = "Received",
            showInLegend = true,
            legendMarkerType = "square",
            type = "area",
            color = "rgba(40,175,101,0.6)",
            markerSize = 0,
            dataPoints = new List<Datapoint>()
            {
                new Datapoint() { date = new DateTime(2017, 2, 6), value = 220 },
                new Datapoint() { date = new DateTime(2017, 2, 7), value = 120 },
                new Datapoint() { date = new DateTime(2017, 2, 8), value = 144 },
                new Datapoint() { date = new DateTime(2017, 2, 9), value = 162 },
                new Datapoint() { date = new DateTime(2017, 2, 10), value = 129 },
                new Datapoint() { date = new DateTime(2017, 2, 11), value = 109 },
                new Datapoint() { date = new DateTime(2017, 2, 12), value = 129 }
            }
        };

        SerieArea Sent = new SerieArea()
        {
            name = "Sent",
            showInLegend = true,
            legendMarkerType = "square",
            type = "area",
            color = "rgba(0,75,141,0.7)",
            markerSize = 0,
            dataPoints = new List<Datapoint>()
            {
                new Datapoint() { date = new DateTime(2017, 2, 6), value = 42 },
                new Datapoint() { date = new DateTime(2017, 2, 7), value = 34 },
                new Datapoint() { date = new DateTime(2017, 2, 8), value = 29 },
                new Datapoint() { date = new DateTime(2017, 2, 9), value = 42 },
                new Datapoint() { date = new DateTime(2017, 2, 10), value = 53 },
                new Datapoint() { date = new DateTime(2017, 2, 11), value = 15 },
                new Datapoint() { date = new DateTime(2017, 2, 12), value = 12 }
            }
        };

        var settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new CustomDateTimeConverter() }
        };

        var jsonReceived = JsonConvert.SerializeObject(Received.dataPoints, settings);
        ViewBag.jsonReceived = jsonReceived;

        var jsonSent = JsonConvert.SerializeObject(Sent.dataPoints, settings);
        ViewBag.jsonSent = jsonSent;

        return View();
    }

    public IActionResult ColumnChart()
    {
        ColumnChartModel model = new ColumnChartModel();
        model.Reserves = new List<ColumnChartDatapoint>()
        {
            new ColumnChartDatapoint() { label = "Saudi", y = 266.21f },
            new ColumnChartDatapoint() { label = "Venezuela", y = 302.25f },
            new ColumnChartDatapoint() { label = "Iran", y = 157.20f },
            new ColumnChartDatapoint() { label = "Iraq", y = 148.77f },
            new ColumnChartDatapoint() { label = "Kuwait", y = 101.50f },
            new ColumnChartDatapoint() { label = "UAE", y = 97.8f }
        };

        model.Production = new List<ColumnChartDatapoint>()
        {
            new ColumnChartDatapoint() { label = "Saudi", y = 10.46f },
            new ColumnChartDatapoint() { label = "Venezuela", y = 2.27f },
            new ColumnChartDatapoint() { label = "Iran", y = 3.99f },
            new ColumnChartDatapoint() { label = "Iraq", y = 4.45f },
            new ColumnChartDatapoint() { label = "Kuwait", y = 2.92f },
            new ColumnChartDatapoint() { label = "UAE", y = 3.1f }
        };

        return View(model);
    }
}

public class CustomDateTimeConverter : IsoDateTimeConverter
{
    public CustomDateTimeConverter()
    {
        DateTimeFormat = "yyyy, MM, dd"; // Adjust month to be zero-based
    }
}
