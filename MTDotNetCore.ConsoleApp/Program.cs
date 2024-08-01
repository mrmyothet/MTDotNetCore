using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTDotNetCore.ConsoleApp;
using MTDotNetCore.ConsoleApp.AdoDotNetExamples;
using MTDotNetCore.ConsoleApp.DapperExamples;
using MTDotNetCore.ConsoleApp.EFCoreExamples;
using MTDotNetCore.ConsoleApp.Services;

//Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Create("title", "author", "content");
////adoDotNetExample.Update(12, "blog title", "blog author", "blog content");
//adoDotNetExample.Delete(12);
//adoDotNetExample.Edit(1002);
//adoDotNetExample.Read();


//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Create("new Title", "new Author", "new Content");

var connectionString = ConnectionStrings.sqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

var services = new ServiceCollection()
    .AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    })
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .BuildServiceProvider();

var db = services.GetRequiredService<AppDbContext>();
EFCoreExample eFCoreExample = new EFCoreExample(db);
eFCoreExample.GenerateBlogData(395);

//AdoDotNetExample adoDotNetExample = services.GetRequiredService<AdoDotNetExample>();
//adoDotNetExample.Create("new Title", "new Author", "new Content");

//DapperExample dapperExample = services.GetRequiredService<DapperExample>();
//dapperExample.Run();

Console.ReadLine();
