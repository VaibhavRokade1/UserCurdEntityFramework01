using EntityFreamework01.Models;

namespace EntityFreamework01.Repository.Defination
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);
        Task<bool> RemoveUser(User user);
        Task<bool> UpadateUser(User user);
        Task<IList<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<bool> IsDuplicate(string username, string email);
        Task<bool> SaveAndChanges(); 
    }
}
