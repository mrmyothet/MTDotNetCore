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
        MultiSeriesAreaChartModel model = new MultiSeriesAreaChartModel();
        model.SerieAreaList = new List<SerieArea>();

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
                new Datapoint() { x = new DateTime(2017, 1, 16), y = 220 },
                new Datapoint() { x = new DateTime(2017, 1, 7), y = 120 },
                new Datapoint() { x = new DateTime(2017, 1, 8), y = 144 },
                new Datapoint() { x = new DateTime(2017, 1, 9), y = 162 },
                new Datapoint() { x = new DateTime(2017, 1, 10), y = 129 },
                new Datapoint() { x = new DateTime(2017, 1, 11), y = 109 },
                new Datapoint() { x = new DateTime(2017, 1, 12), y = 129 }
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
                new Datapoint() { x = new DateTime(2017, 1, 6), y = 42 },
                new Datapoint() { x = new DateTime(2017, 1, 7), y = 34 },
                new Datapoint() { x = new DateTime(2017, 1, 8), y = 29 },
                new Datapoint() { x = new DateTime(2017, 1, 9), y = 42 },
                new Datapoint() { x = new DateTime(2017, 1, 10), y = 53 },
                new Datapoint() { x = new DateTime(2017, 1, 11), y = 15 },
                new Datapoint() { x = new DateTime(2017, 1, 12), y = 12 }
            }
        };

        model.SerieAreaList.Add(Received);
        model.SerieAreaList.Add(Sent);

        var settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new CustomDateTimeConverter() }
        };

        var receivedJson = JsonConvert.SerializeObject(Received.dataPoints, settings);
        ViewBag.receivedJson = receivedJson;

        return View();
    }
}

public class CustomDateTimeConverter : IsoDateTimeConverter
{
    public CustomDateTimeConverter()
    {
        DateTimeFormat = "yyyy, M, dd"; // Adjust month to be zero-based
    }
}
