using MTDotNetCore.ConsoleAppEFCore.Database.Models;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();
var lst = db.TblPieCharts.ToList();
foreach (var item in lst)
{
    Console.WriteLine($"{item.PieChartName} , {item.PieChartValue}");
}

Console.ReadLine();
