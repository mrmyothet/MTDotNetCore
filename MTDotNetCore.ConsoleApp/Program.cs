using MTDotNetCore.ConsoleApp;
using MTDotNetCore.ConsoleApp.AdoDotNetExamples;
using System.Data;
using System.Data.SqlClient;

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

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Create("new Title", "new Author", "new Content");

Console.ReadLine();
