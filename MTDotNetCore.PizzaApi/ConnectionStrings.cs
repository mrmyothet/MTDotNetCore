using System.Data.SqlClient;

namespace MTDotNetCore.PizzaApi;

public static class ConnectionStrings
{
    public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
    {
        DataSource = "MYOTHETPC\\MSSQLSERVER2012",
        InitialCatalog = "DotNetTrainingBatch4",
        UserID = "sa",
        Password = "admin123!", 
        TrustServerCertificate = true
    };
    
}
