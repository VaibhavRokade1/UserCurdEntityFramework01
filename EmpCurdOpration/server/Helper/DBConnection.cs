using Microsoft.Data.SqlClient;
namespace EmplyoeeCurdApi.Helper
{
    public class DBConnection
    {
        private SqlConnection conn = null;
        private readonly string ConString = "Server=(localdb)\\MSSQLLocalDB;Database=EmpCrud;Trusted_Connection=True;";
        public SqlConnection GetDBConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(ConString);
                return conn;
            }
            else
                return conn;
        } 
    }
}
