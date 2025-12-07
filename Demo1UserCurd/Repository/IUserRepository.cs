using Demo1UserCurd.Dto;
using Demo1UserCurd.Models;

namespace Demo1UserCurd.Repository
{
    public interface IUserRepository
    {
        public Task<bool> AddUser(AddUserDto user);
        public Task<bool> UpdateUser(int uid,  UpdateUserDto updateUserDto);
        public Task<bool> DeleteUser(int uid);
        public Task<User> GetUserByEmail(string email);
        public Task<IList<User>> GetAllUsers();
    }
}
