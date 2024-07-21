namespace MTDotNetCore.MvcChartApp.Models.CanvasJs
{
    public class ColumnChartModel
    {
        public List<ColumnChartDatapoint>? Reserves { get; set; }
        public List<ColumnChartDatapoint>? Production { get; set; }
    }

    public class ColumnChartDatapoint
    {
        public string? label { get; set; }
        public float y { get; set; }
    }
}
