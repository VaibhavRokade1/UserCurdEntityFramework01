using EntityFreamework01.Models;
using EntityFreamework01.Repository.Defination;

namespace EntityFreamework01.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repo;
        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }
        public async Task<bool> DeleteUser(int id)
        {
           User u= await this.repo.GetUserById(id);
          return await this.repo.RemoveUser(u);
        }

        public async Task<IList<User>> GetAllUser() => await this.repo.GetAllUser();


        public async Task<User> GetUserById(int id) => await this.repo.GetUserById(id);
       

        public async Task<bool> Login(string identifire, string password)
        {
           IList<User> users=await this.repo.GetAllUser();
           User u= users.FirstOrDefault(ob => ob.Name == identifire || ob.Email == identifire);
            if (u == null)
            {
                return false;
            }
          return BCrypt.Net.BCrypt.Verify(password, u.Password);
        }

        public async Task<bool> Register(User u)
        {
           bool res=await this.repo.IsDuplicate(u.Name, u.Email);
            if (res)
            {
                return false;
            }
            u.Password=BCrypt.Net.BCrypt.HashPassword(u.Password);
          return await this.repo.AddUser(u);
        }

        public async Task<bool> UpdateUser(int id, User u)
        {
            User exitingUser= await this.repo.GetUserById(id);
            if (exitingUser == null)
                return false;
            exitingUser.Name = u.Name;
            exitingUser.Email = u.Email;
            exitingUser.Password= BCrypt.Net.BCrypt.HashPassword(u.Password);
           return await this.repo.UpadateUser(exitingUser);

        }
    }
}
