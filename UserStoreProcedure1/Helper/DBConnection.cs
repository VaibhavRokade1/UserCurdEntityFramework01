using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStoreProcedure1.Helper
{
    public class DBConnection
    {
        public static SqlConnection GetDBConnection() 
        {
            string conString = "Server=(localdb)\\MSSQLLocalDB;Database=User_DB;Trusted_Connection=True;";
            SqlConnection conn = null;
            if (conn == null)
                return new SqlConnection(conString);
            else
                return conn;
        }
    }
}
