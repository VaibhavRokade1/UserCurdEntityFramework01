using Demo1UserCurd.Dto;
using Demo1UserCurd.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1UserCurd.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUser(AddUserDto user)
        {
            try
            {
                   
               await _context.tblDemo1User.AddAsync(
                    new User() 
                    { 
                      Name=user.Name ,
                      Email=user.Email,
                      PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash, 10),
                      Contact = user.Contact 
                    });

                var res = await _context.SaveChangesAsync() > 0;

                return res ? true : false;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _context.tblDemo1User.FindAsync(id);
                if (user == null) 
                {
                    return false;
                }

                _context.tblDemo1User.Remove(user);
                var res = await _context.SaveChangesAsync() > 0;
                
                return res ?  true : false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public async Task<IList<User>> GetAllUsers()
        {
            try
            {
                var userlist = await _context.tblDemo1User.ToListAsync();
                if (userlist == null) 
                {
                    return null;
                }
                return userlist;
            }
            catch( Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            

        }

        public async Task<User?> GetUserByEmail(string email)
        {
            try
            {
                var user = await _context.tblDemo1User.FirstOrDefaultAsync(u => u.Email == email);
                return user == null ? null : user;

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateUser(int uid, UpdateUserDto updateUserDto)
        {
            try
            {
                var user =  await _context.tblDemo1User.FindAsync(uid);

                if (user != null)
                {
                    user.Name = updateUserDto.Name;
                    user.Email = updateUserDto.Email;
                    user.Contact = updateUserDto.Contact;

                    _context.tblDemo1User.Update(user);
                    var res = await _context.SaveChangesAsync() > 0;

                    return true;

                }
                else
                    return false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
