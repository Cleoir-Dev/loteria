using System.Configuration;
using System.Data.SqlClient;

namespace softlotery.DAL
{
    public static class BasicDAL
    {
        private static SqlConnection sqlConnection;
        private static string sqlConnectionString;
        public static string DbConnectionString()
        {
            sqlConnectionString = ConfigurationManager.ConnectionStrings["conexaoSQL"].ConnectionString;
            return sqlConnectionString;
        }

        public static SqlConnection DbConnection()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoSQL"].ConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

       
    }
}
