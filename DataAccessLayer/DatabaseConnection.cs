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
                UserID = "STUDENT19",
                Password = "OPENDB_19",
                InitialCatalog = "DB19",
                TrustServerCertificate = true
            };
            return builder.ToString();
        }
    }
}