namespace MTDotNetCore.MvcChartApp.Models.HighChart;

public class LineChartModel
{
    public List<LineChartData>? DataList { get; set; }
}

public class LineChartData
{
    public string? name { get; set; }

    public List<double> data { get; set; } = new List<double>();
}
