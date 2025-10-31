using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCURD.Models;

namespace UserCURD.Repository
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        List<User> SelectUsers();
        User SelectByID(int id);

        List<User> SelectByName(string str);
    }
}
