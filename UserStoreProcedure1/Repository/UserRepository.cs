using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStoreProcedure1.Helper;
using UserStoreProcedure1.Models;

namespace UserStoreProcedure1.Repository
{
    public class UserRepository : IUserRepository
    {
        SqlConnection conn = DBConnection.GetDBConnection();
        public bool CreateUser(User user)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_users", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action"  , "insert");
                cmd.Parameters.AddWithValue("@uname", user.Uname);
                cmd.Parameters.AddWithValue("@uemail", user.Uemail);
                cmd.Parameters.AddWithValue("@upass", user.Upassword);
                cmd.Parameters.AddWithValue("@uage", user.Uage);

                int res = cmd.ExecuteNonQuery();

                conn.Close();
                return res > 0 ? true : false;


            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error UserRepository : ");
                Console.WriteLine(ex.Message);
                return false;
            }
           
        }
    }
}
