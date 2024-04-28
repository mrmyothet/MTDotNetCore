using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {
            Read();
        }

        private void Read() 
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

            List<dynamic> lst =  db.Query("select * from tbl_blog").ToList();
            Console.WriteLine(lst.Count);


        }
    }
}
