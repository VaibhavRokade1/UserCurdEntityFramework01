using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Store_Procedure.Models;
using User_Store_Procedure.Repository;

namespace User_Store_Procedure.Controllers
{
    public class UserController
    {
        public static void ControlUser(Task<bool> _)
        {
         UserRepository repo = new UserRepository();
            User user = new User();
            while (true) 
            {
                Console.WriteLine("1. Add User ");
                int choice = 0;

                switch (choice) 
                {
                    case 1:
                        Console.WriteLine("Enter a User Name : ");
                        user.Uname = Console.ReadLine();
                        Console.WriteLine("Enter a User Email : ");
                        user.Uemail= Console.ReadLine();
                        Console.WriteLine("Enter a User Password : ");
                        user.Upassword= Console.ReadLine();
                        Console.WriteLine("Enter a User Age : ");
                        user.Uage= int.Parse(Console.ReadLine());

                        _ = repo.CreateUser(user, "insert");
                         break;
                }
            }
        }
    }
}
