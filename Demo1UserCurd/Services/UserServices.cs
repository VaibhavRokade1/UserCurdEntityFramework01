using Demo1UserCurd.Dto;
using Demo1UserCurd.Models;
using Demo1UserCurd.Repository;

namespace Demo1UserCurd.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _repo;
        public UserServices(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddNewUser(AddUserDto addUserDto)
        {
            if (
                addUserDto.Name.Trim() == "" || 
                addUserDto.Email.Trim() == "" || 
                addUserDto.PasswordHash.Trim() =="" || 
                addUserDto.Contact.ToString().Trim() == "" 
                ) 
            {
                return false;
            }
            else 
            {

               var res = await _repo.AddUser(addUserDto);
                return res ? true : false;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            var res = await _repo.DeleteUser(id);
            if (res) 
            {
                return true;
            }
            return false;
        }

        public async Task<IList<User>> GetAllUsers()
        {
           var userlist = await _repo.GetAllUsers();
            if (userlist == null)
            {
                return null;
            }
            else
                return userlist;
        }

        public async Task<bool> UpdateUserById(int id, UpdateUserDto updateUserDto)
        {
            try
            {
                if (
                    updateUserDto.Name.Trim() == "" || 
                    updateUserDto.Email.Trim() == "" || 
                    updateUserDto.Contact.ToString().Trim() == ""
                    ) 
                {
                    return false;
                }
                var res = await _repo.UpdateUser(id, updateUserDto);

                return res ? true : false;
            }
            catch( Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
