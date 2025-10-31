using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCURD.Models;

namespace UserCURD.Services
{
    public interface IUserServices
    {
        void AddUser(User user);
    }
}
