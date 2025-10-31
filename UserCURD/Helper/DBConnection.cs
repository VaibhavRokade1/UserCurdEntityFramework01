using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCURD.Helper
{
    public class DBConnection
    {
        public static SqlConnection conn = null;
        public static SqlConnection GetDBConnection()
        {
            string ConString = "Server=(localdb)\\MSSQLLocalDB;Database=User_DB;Trusted_Connection=True;";

            if (conn == null)
            {
                return new SqlConnection(ConString);
            }
            else
            {
            return conn;
            }
        }
    }
}
