using EntityFreamework01.Data;
using EntityFreamework01.Models;
using EntityFreamework01.Repository.Defination;
using Microsoft.EntityFrameworkCore;

namespace EntityFreamework01.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext db;

        public UserRepository(UserDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> AddUser(User user)
        {
            await db.TblUser.AddAsync(user);
          return  await this.SaveAndChanges();
        }

        public async Task<IList<User>> GetAllUser()
     => await this.db.TblUser.ToListAsync();
        public async Task<User> GetUserById(int id)=>        
            await this.db.TblUser.FirstOrDefaultAsync(ob => ob.UId == id);

        public async Task<bool> IsDuplicate(string username, string email)
        {
           return await this.db.TblUser.AnyAsync(ob => ob.Name == username || ob.Email == email);
        }

        public async Task<bool> RemoveUser(User user)
        {
            db.TblUser.Remove(user);
            return  await this.SaveAndChanges();
        }

        public async Task<bool> SaveAndChanges()
        {
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpadateUser(User user)
        {
            db.TblUser.Update(user);
            return await this.SaveAndChanges();
        }
    }
}
