using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDotNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        // Use Dependency Injection configured at Program.cs

        //private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder =
        //    new SqlConnectionStringBuilder()
        //    {
        //        DataSource = "MYOTHETPC\\MSSQLSERVER2012", // SQL Server Name
        //        InitialCatalog = "DotNetTrainingBatch4", // database name
        //        UserID = "sa",
        //        Password = "admin123!"
        //    };

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public AdoDotNetExample(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
        }

        public void Read()
        {
            SqlConnection connection = new SqlConnection(
                _sqlConnectionStringBuilder.ConnectionString
            );
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
        }

        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(
                _sqlConnectionStringBuilder.ConnectionString
            );
            connection.Open();
            Console.WriteLine("Connection Open.");

            string query = "select * from tbl_blog where BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection Close.");

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            DataRow dr = dt.Rows[0];

            Console.WriteLine("Blog Id => " + dr["BlogId"]);
            Console.WriteLine("Blog Id => " + dr["BlogTitle"]);
            Console.WriteLine("Blog Id => " + dr["BlogAuthor"]);
            Console.WriteLine("Blog Id => " + dr["BlogContent"]);
            Console.WriteLine("--------------------------------");
        }

        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(
                _sqlConnectionStringBuilder.ConnectionString
            );
            connection.Open();
            Console.WriteLine("Connection Open.");

            string query =
                @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            string message = result > 0 ? "Saving successful." : "Saving failed.";
            Console.WriteLine(message);

            connection.Close();
            Console.WriteLine("Connection Close.");
        }

        public void Update(int BlogId, string blogTitle, string blogAuthor, string blogContent)
        {
            SqlConnection connection = new SqlConnection(
                _sqlConnectionStringBuilder.ConnectionString
            );
            connection.Open();
            Console.WriteLine("Connection Open.");

            string query =
                @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE [BlogId] = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", BlogId);
            cmd.Parameters.AddWithValue("@BlogTitle", blogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blogContent);

            int result = cmd.ExecuteNonQuery();

            string message = result > 0 ? "Update successful." : "Update failed.";
            Console.WriteLine(message);

            connection.Close();
            Console.WriteLine("Connection Close.");
        }

        public void Delete(int BlogId)
        {
            SqlConnection connection = new SqlConnection(
                _sqlConnectionStringBuilder.ConnectionString
            );
            connection.Open();
            Console.WriteLine("Connection Open.");

            string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", BlogId);

            int result = cmd.ExecuteNonQuery();

            string message = result > 0 ? "Delete successful." : "Delete failed.";
            Console.WriteLine(message);

            connection.Close();
            Console.WriteLine("Connection Close.");
        }
    }
}
