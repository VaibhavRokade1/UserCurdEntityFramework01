using ADO.NET_Store_Procedure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Store_Procedure.Repository
{
    public interface IUserRepository
    {
        bool CreateUser(User user, string action);
    }
}
