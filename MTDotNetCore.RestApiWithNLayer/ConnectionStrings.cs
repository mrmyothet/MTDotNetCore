using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDotNetCore.RestApiWithNLayer
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "MYOTHETPC\\MSSQLSERVER2012",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "admin123!",
            TrustServerCertificate = true
        };

    }
}
