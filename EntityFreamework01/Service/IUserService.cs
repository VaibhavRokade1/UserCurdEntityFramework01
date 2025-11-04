using EntityFreamework01.Models;

namespace EntityFreamework01.Service
{
    public interface IUserService
    {
        Task<bool> Register(User u);
        Task<bool> Login(string identifire, string password);
        Task<bool> UpdateUser(int id,User u);
        Task<bool> DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<IList<User>> GetAllUser();

    }
}
