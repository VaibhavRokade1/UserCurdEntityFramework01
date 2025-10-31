using ADO.NET_Store_Procedure.Models;
using ADO.NET_Store_Procedure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Store_Procedure.Controllers
{
    public class UserController
    {
        public static void ControlUser()
        {
            UserRepository repo = new UserRepository();
            User user = new User();
            while (true)
            {
                Console.WriteLine("1. Add User ");
                int choice = 0;

                choice = int.Parse(Console.ReadLine());
    
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter a User Name : ");
                        user.Uname = Console.ReadLine();
                        Console.WriteLine("Enter a User Email : ");
                        user.Uemail = Console.ReadLine();
                        Console.WriteLine("Enter a User Password : ");
                        user.Upassword = Console.ReadLine();
                        Console.WriteLine("Enter a User Age : ");
                        user.Uage = int.Parse(Console.ReadLine());

                        var res = repo.CreateUser(user, "insert");

                        //Console.WriteLine(res);
                        break;
                }
            }
        }
    }
}
