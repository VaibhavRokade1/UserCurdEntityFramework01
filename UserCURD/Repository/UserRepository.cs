using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCURD.Helper;
using UserCURD.Models;

namespace UserCURD.Repository
{
    public  class UserRepository : IUserRepository
    {
        readonly SqlConnection conn = DBConnection.GetDBConnection();
        public bool CreateUser(User user) 
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_users" , conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action" , "insert"); 
                cmd.Parameters.AddWithValue("@uname" , user.Uname) ;
                cmd.Parameters.AddWithValue("@uemail" , user.Uemail); 
                cmd.Parameters.AddWithValue("@uage" , user.Uage);

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Upassword);

                cmd.Parameters.AddWithValue("@upass" , hashedPassword); 

               int res =  cmd.ExecuteNonQuery();

                conn.Close();

                if (res > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            
        }
        public bool UpdateUser(User user)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_users", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
                cmd.Parameters.AddWithValue("@uid", user.Uid);
                cmd.Parameters.AddWithValue("@uname", user.Uname);
                cmd.Parameters.AddWithValue("@uemail", user.Uemail);
                cmd.Parameters.AddWithValue("@uage", user.Uage);

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Upassword);

                cmd.Parameters.AddWithValue("@upass", hashedPassword);

                int res = cmd.ExecuteNonQuery();
                conn.Close();

                if (res > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        }
        public bool DeleteUser(int id) 
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_users", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@uid", id);

                int res = cmd.ExecuteNonQuery();
                conn.Close();

                if (res > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
        public List<User> SelectUsers() 
        {
            try
            {
                User user = new User();
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_users" , conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action" , "select" );
                SqlDataReader reader = cmd.ExecuteReader();

                List<User> userslist = new List<User>();
                while (reader.Read()) 
                {
                    user.Uid = (int)reader["uid"];
                    user.Uname = (string)reader["uname"];
                    user.Uemail = (string)reader["uemail"];
                    user.Uage = (int)reader["uage"];

                    userslist.Add(user);
                }
                conn.Close();
                return userslist;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
                
            }
        }
        public User SelectByID(int id) 
        {
                User user = null;
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_users", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", "selectById");
                cmd.Parameters.AddWithValue("@uid", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User()
                    {
                        Uid = (int)reader["uid"],
                        Uname = (string)reader["uname"],
                        Uemail = (string)reader["uemail"],
                        Uage = (int)reader["uage"]
                    };
                }
                
                conn.Close();
                return user;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return user;
            }

        }

        public List<User> SelectByName(string name)
        {
            List<User> usersList = new List<User>();
            User user = new User();
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_users", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", "selectByName");
                cmd.Parameters.AddWithValue("@uname",name);

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()) 
                {
                    user = new User()
                    {
                        Uid = (int)reader["uid"],
                        Uname = (string)reader["uname"],                                        
                        Uemail = (string)reader["uemail"],
                        Uage = (int)reader["uage"]
                    };

                    usersList.Add(user);
                }
                return usersList;
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace); 
                return usersList;

            }
        }
    }
}
