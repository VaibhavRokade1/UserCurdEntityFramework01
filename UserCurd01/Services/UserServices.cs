using UserCurd01.Dto;
using UserCurd01.Models;
using UserCurd01.Repository;

namespace UserCurd01.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repo;
        public UserServices(IUserRepository repo)
        {
            this._repo = repo;
        }
        public async Task<bool> AddNewUser(AddUserDto addUserDto)
        {

            if (addUserDto.Password.Trim() == "" || addUserDto.Name.Trim() == "" || addUserDto.Email.Trim() == "" || addUserDto.Contact.ToString().Trim() == "")
                return false;
            try
            {
                var res = await _repo.AddUser(addUserDto);

                return res ? true : false;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IList<User>> GetAllUsers()
        {
            var list = await _repo.GetAllUsers();
            if (list == null)
            {
                return null;
            }
            else return list;
        }

        public async Task<bool> DeleteById(int id) 
        {
            if (id <= 0)
                return false;


            var res = await _repo.DeleteById(id);

            return res ? true : false;
        }

        public async Task<bool> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            if (id < 1) 
            {
                return false;

            }
            if (updateUserDto.Email.Trim() == "" || updateUserDto.Name.Trim() == "" || updateUserDto.Contact.ToString().Trim() == "") 
            {
                return false;
            }

           var res = await  _repo.UpdateUser(id , updateUserDto);

            return res ? true : false;
        }
    }
}
