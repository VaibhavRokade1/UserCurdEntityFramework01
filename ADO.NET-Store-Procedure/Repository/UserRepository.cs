using ADO.NET_Store_Procedure.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using ADO.NET_Store_Procedure.Helper;

namespace ADO.NET_Store_Procedure.Repository
{
    public class UserRepository : IUserRepository
    {

        readonly SqlConnection conn = DBConnection.GetDBConnection();
        public bool CreateUser(User user, string action)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_users", conn);

                // command specification
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parametters
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@uname", user.Uname);
                cmd.Parameters.AddWithValue("@uemail", user.Uemail);
                cmd.Parameters.AddWithValue("@uage", user.Uage);

                // Hash the password using BCrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Upassword);

                // Pass the hashed password to the stored procedure
                cmd.Parameters.AddWithValue("@upass", hashedPassword);


                int res =  cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
