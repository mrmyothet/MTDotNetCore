using System.Data;
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

SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
// SqlConnection connection = new SqlConnection("Data Source=SOLIDCAD-SERVER\\SQLEXPRESS2012;Initial Catalog=DotNetTrainingBatch4;User ID=sa;Password=admin123!");
connection.Open();
Console.WriteLine("Connection Open.");

// Ado.Net Read
string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);

connection.Close();
Console.WriteLine("Connection Close.");

/* 
 * DataSet => DataTable
 * DataTable => DataRow
 * DataRow => DataColumn
*/

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["BlogId"]);
    Console.WriteLine("Blog Id => " + dr["BlogTitle"]);
    Console.WriteLine("Blog Id => " + dr["BlogAuthor"]);
    Console.WriteLine("Blog Id => " + dr["BlogContent"]);
    Console.WriteLine("--------------------------------");
}

Console.ReadKey();
