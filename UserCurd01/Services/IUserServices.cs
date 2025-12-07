using UserCurd01.Dto;
using UserCurd01.Models;

namespace UserCurd01.Services
{
    public interface IUserServices
    {
        public Task<bool> AddNewUser(AddUserDto addUserDto);
        public Task<IList<User>> GetAllUsers();
        public Task<bool> UpdateUser(int id, UpdateUserDto updateUserDto);
        public Task<bool> DeleteById(int id);
    }
}
