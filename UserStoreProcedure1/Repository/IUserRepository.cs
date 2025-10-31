using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStoreProcedure1.Models;

namespace UserStoreProcedure1.Repository
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
    }
}
