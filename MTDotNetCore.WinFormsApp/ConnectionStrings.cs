using System.Data.SqlClient;

namespace MTDotNetCore.WinFormsApp
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = "MYOTHETPC\\MSSQLSERVER2012",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "admin123!",
            TrustServerCertificate = true
        };
    }
}
