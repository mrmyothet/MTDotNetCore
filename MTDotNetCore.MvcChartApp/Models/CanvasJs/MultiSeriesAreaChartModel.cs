using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MTDotNetCore.MvcChartApp.Models.CanvasJs
{
    public class MultiSeriesAreaChartModel
    {
        public List<SerieArea> SerieAreaList { get; set; } = new List<SerieArea>();
    }

    public class SerieArea
    {
        public string name { get; set; }
        public bool showInLegend { get; set; }
        public string legendMarkerType { get; set; }
        public string type { get; set; }
        public string color { get; set; }
        public int markerSize { get; set; }
        public List<Datapoint>? dataPoints { get; set; }
    }

    public class Datapoint
    {
        public DateTime date { get; set; }
        public int value { get; set; }
    }
}
