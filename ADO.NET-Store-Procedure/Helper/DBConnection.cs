using System;
using System.Data.SqlClient;

namespace ADO.NET_Store_Procedure.Helper
{
    public static class DBConnection
    {

        public SqlConnection GetDBConnection()
        {
            string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=Users;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                Console.WriteLine("Connection successful!");
            }
            return new SqlConnection(connStr);
        }
           
     }
}