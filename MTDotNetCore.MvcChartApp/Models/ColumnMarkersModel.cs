namespace MTDotNetCore.MvcChartApp.Models
{
    public class ColumnMarkersModel
    {
        public string Name { get; set; }
        public List<List<Datum>> Data { get; set; }
    }

    public class Datum
    {
        public string x { get; set; }
        public int y { get; set; }
        public Goal[] goals { get; set; }
    }

    public class Goal
    {
        public string name { get; set; }
        public int value { get; set; }
        public int strokeHeight { get; set; }
        public string strokeColor { get; set; }
    }
}
