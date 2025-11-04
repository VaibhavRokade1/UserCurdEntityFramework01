using UserBackendProject.Models;
using UserBackendProject.UserDTO;

namespace UserBackendProject.Service
{
    public interface IUserService
    {
       public Task<bool> Register(UserRegisterDTO user);
       public Task<bool> UpdateUser(int id, User user);
       public Task<bool> DeleteUser(int id);
       public Task<User> GetUserByID(int id);
       public Task<bool> IsUserDublicate(string name, string email);
       public Task<List<User>> GetAllUsers();
       public Task<User> LoginUser(string name, string password);
    }
}
