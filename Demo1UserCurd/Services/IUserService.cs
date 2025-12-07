using Demo1UserCurd.Dto;
using Demo1UserCurd.Models;

namespace Demo1UserCurd.Services
{
    public interface IUserService
    {
        public Task<bool> AddNewUser(AddUserDto addUserDto);    
        public Task<bool> UpdateUserById(int id ,UpdateUserDto updateUserDto);    
        public Task<bool> DeleteById(int id);    
        public Task<IList<User>> GetAllUsers();  
    }
}
