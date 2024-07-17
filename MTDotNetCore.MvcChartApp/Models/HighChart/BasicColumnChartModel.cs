namespace MTDotNetCore.MvcChartApp.Models.HighChart;

public class BasicColumnChartModel
{
    public List<string> Countries { get; set; } = new List<string>();
    public List<CropData> DataList { get; set; } = new List<CropData>();

    public class CropData
    {
        public string? name { get; set; }
        public int[]? data { get; set; }
    }
}
