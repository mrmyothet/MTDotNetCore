using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/DotNetTrainingBatch4.ConsoleAppLogging.log",
        rollingInterval: RollingInterval.Hour
    )
    .CreateLogger();

Log.Fatal("This is Fatal Log");
Log.Error("This is Error Log");

Console.WriteLine("Hello World!");

Log.Information("Starting a program");

int a = 10,
    b = 0;
try
{
    Log.Debug("Dividing {A} by {B}", a, b);
    Console.WriteLine(a / b);
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    await Log.CloseAndFlushAsync();
}
