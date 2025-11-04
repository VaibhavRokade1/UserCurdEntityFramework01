using UserBackendProject.Models;
using UserBackendProject.Repository;
using UserBackendProject.Service;
using UserBackendProject.UserDTO;

namespace UserBackendProject.Services
{
    public class UserServices : IUserService
    {
        public readonly IUserRepository _userRepo;

        public UserServices(IUserRepository userRepository) 
        {
            this._userRepo = userRepository;
        }

        public async Task<bool> Register(UserRegisterDTO user)
        {
            try 
            {
                
                
                    _userRepo.AddUser(user);
                    return true;
               
            }catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserDublicate(string name, string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoginUser(string name, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
