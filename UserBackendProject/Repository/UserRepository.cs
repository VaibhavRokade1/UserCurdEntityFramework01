using Microsoft.EntityFrameworkCore;
using UserBackendProject.Models;
using UserBackendProject.UserDTO;

namespace UserBackendProject.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly UserDbContext UserDB ;

        public UserRepository(UserDbContext userDB)
        {
            this.UserDB = userDB;
        }
        public async Task<bool> AddUser(UserRegisterDTO user)
        {
            var entity = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };

            await UserDB.Users.AddAsync(entity);
            var result = await UserDB.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var user = await UserDB.Users.FirstOrDefaultAsync(u => u.Id == id);
            try 
            {
                if (user != null)
                {
                    UserDB.Users.Remove(user);
                    var res = await UserDB.SaveChangesAsync();

                    if (res > 0)
                        return true;
                    else
                        return false;
                }

            }
            catch (Exception ex) 
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            return false; 
            
            }
                     
            return false; 

        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var userList = await UserDB.Users.ToListAsync();
                return userList;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);            
                Console.WriteLine(ex.StackTrace);

                return new List<User>();
            }
        }

        public async Task<bool> UpdateUser(int id, User user)
        {
            try
            {
                var u = await UserDB.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (u != null)
                {
                    u.Name = user.Name;
                    u.Email = user.Email;
                    u.Address = user.Address;
                }
                await UserDB.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            
            }



        }

        public async Task<User> GetUserByID(int id)
        {
            try
            {
                var user =  await UserDB.Users.FirstOrDefaultAsync(u=>u.Id == id);

                if (user != null)
                {
                    return user;
                }
                else 
                {
                    return new User();
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                return new User(); 
            }
        }

        public async Task<bool> IsUserDublicate(string name, string email)
        {
            try
            {
                var user = await UserDB.Users.FirstOrDefaultAsync(u => u.Name == name && u.Email ==email);

                if (user == null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

       

    }
}
