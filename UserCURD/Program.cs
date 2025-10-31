using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCURD.Models;
using UserCURD.Repository;

namespace UserCURD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserRepository repo = new UserRepository();

            User user = new User();
            //Console.WriteLine(user);

            //repo.UpdateUser(user);
            //List<User> ulist =  repo.SelectUsers();

            //ulist.ForEach((u)=>Console.WriteLine(u));

            //repo.DeleteUser(3);

            //user =  repo.SelectByID(1);


            //List<User> ulisst= repo.SelectByName("V");

            //ulisst.ForEach(Console.WriteLine);
        }
    }
}
