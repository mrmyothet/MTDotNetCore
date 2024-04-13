using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

// Ctrl + . => suggestion 

// F9  => Breakpoint
// F10 => Debug line by line

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "SOLIDCAD-SERVER\\SQLEXPRESS2012"; // SQL Server Name 
stringBuilder.InitialCatalog = "DotNetTrainingBatch4"; // database name 
stringBuilder.UserID = "sa";
stringBuilder.Password = "admin123!";

// SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
SqlConnection connection = new SqlConnection("Data Source=SOLIDCAD-SERVER\\SQLEXPRESS2012;Initial Catalog=DotNetTrainingBatch4;User ID=sa;Password=admin123!");
connection.Open();
Console.WriteLine("Connection Open.");

connection.Close();
Console.WriteLine("Connection Close.");

Console.ReadKey();
