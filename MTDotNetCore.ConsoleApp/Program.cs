using MTDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");



AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

adoDotNetExample.Create("title", "author", "content");

adoDotNetExample.Read();

Console.ReadLine();
