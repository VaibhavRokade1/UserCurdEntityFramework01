using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Store_Procedure.Helper
{
    public static class DBConnection
    {
        public static SqlConnection GetDBConnection()
        {
            string Con_String = "Server=(localdb)\\MSSQLLocalDB;Database=Users;Trusted_Connection=True;";

            SqlConnection conn = null;

            if (conn == null)
            {
                return new SqlConnection(Con_String);
            }
            else
            {
                return conn;
            }
        }
    }
}

