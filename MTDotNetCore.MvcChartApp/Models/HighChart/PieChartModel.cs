namespace MTDotNetCore.MvcChartApp.Models.HighChart
{
    public class PieChartModel
    {
        public List<DataPoint>? DataList { get; set; }
    }

    public class DataPoint
    {
        public string? Name { get; set; }
        public double y { get; set; }
    }
}
