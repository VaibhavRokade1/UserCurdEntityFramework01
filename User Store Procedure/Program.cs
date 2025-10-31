using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Store_Procedure.Controllers;

namespace User_Store_Procedure
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserController.ControlUser(_);
        }
    }
}
