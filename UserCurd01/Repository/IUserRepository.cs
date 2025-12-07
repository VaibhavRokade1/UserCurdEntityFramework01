using UserCurd01.Dto;
using UserCurd01.Models;

namespace UserCurd01.Repository
{
    public  interface IUserRepository
    {
        public Task<bool> AddUser(AddUserDto addUserDto);
        public Task<IList<User>> GetAllUsers();
        public Task<bool> UpdateUser(int id , UpdateUserDto updateUserDto);
        public Task<bool> DeleteById(int id);
    }
}
