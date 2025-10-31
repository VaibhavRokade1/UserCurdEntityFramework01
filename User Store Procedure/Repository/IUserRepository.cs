using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Store_Procedure.Models;

namespace User_Store_Procedure.Repository
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user ,string action);
    }
}
