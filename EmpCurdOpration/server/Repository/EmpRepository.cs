using EmplyoeeCurdApi.Helper;
using EmplyoeeCurdApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmplyoeeCurdApi.Repository
{
    public class EmpRepository : IEmpRepository
    {
        DBConnection DBinstance = new DBConnection();
        public SqlConnection conn;

        public EmpRepository()
        {
            conn = DBinstance.GetDBConnection();
        }

        public bool AddEmp(Employee employee)
        {
            try
            {
                conn.Open();
                var cmd = new SqlCommand("sp_Emps", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@ename", employee.Ename);
                cmd.Parameters.AddWithValue("@esalary", employee.Esalary);
                cmd.Parameters.AddWithValue("@edept", employee.Edept);

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool UpdateEmp( int id ,  Employee employee)
        {
            try
            {
                conn.Open();
                var cmd = new SqlCommand("sp_Emps", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@eid", id);
                cmd.Parameters.AddWithValue("@ename", employee.Ename);
                cmd.Parameters.AddWithValue("@esalary", employee.Esalary);
                cmd.Parameters.AddWithValue("@edept", employee.Edept);

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool DeleteEmp(int eid)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_Emps", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Action", "Delete");
                cmd.Parameters.AddWithValue("@eid" , eid);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public List<Employee> ShowEmp()
        {
                List<Employee> emplist = new List<Employee>();
            try
            {
               

                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_Emps", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Action" , "Select");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    emplist.Add(new Employee()
                    {
                        Eid = (int)reader["eid"],
                        Ename = reader["ename"].ToString(),
                        Esalary = Convert.ToSingle(reader["esalary"]),
                        Edept = reader["edept"].ToString()
                    }); 
                }
                conn.Close();
                return emplist;
            }
            catch (Exception ex) 
            {
                conn.Close();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return emplist;
            }
        }
    }
}
