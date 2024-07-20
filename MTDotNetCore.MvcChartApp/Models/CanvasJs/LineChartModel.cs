namespace MTDotNetCore.MvcChartApp.Models.CanvasJs;

public class LineChartModel
{
    public List<DataPoint> DataList { get; set; } = new List<DataPoint>();
}

public class DataPoint
{
    public int y { get; set; }
    public string? indexLabel { get; set; }
    public string? markerColor { get; set; }
    public string? markerType { get; set; }
}
