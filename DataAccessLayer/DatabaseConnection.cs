using System.Data.SqlClient;

namespace EksamensprojektMedDatabaseAdgang.DataAccessLayer
{
    public class DatabaseConnection
    {
        public string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "10.56.8.37",
                UserID = "STUDENT10",
                Password = "OPENDB_10",
                InitialCatalog = "DB10",
                TrustServerCertificate = true
            };
            return builder.ToString();
        }
    }
}