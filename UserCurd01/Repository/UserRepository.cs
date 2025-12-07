using Microsoft.EntityFrameworkCore;
using UserCurd01.Dto;
using UserCurd01.Models;

namespace UserCurd01.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUser(AddUserDto addUserDto)
        {
            try
            {
               var pHash = BCrypt.Net.BCrypt.HashPassword(addUserDto.Password, 10);
              await  _context.tblUsers.AddAsync(new User() { Name = addUserDto.Name , Email= addUserDto.Email , Password = pHash , Contact= addUserDto.Contact });
              var res = await  _context.SaveChangesAsync() > 0;

                return res ? true : false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                var user = await _context.tblUsers.FindAsync(id);
                if (user == null)
                {
                    return false;
                }
                else 
                {
                    _context.tblUsers.Remove(user);
                   var res =   await _context.SaveChangesAsync() > 0;

                    return res ? true : false;
                }

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
                var ulist = await _context.tblUsers.ToListAsync();
                return ulist == null ? null : ulist;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateUser(int id , UpdateUserDto updateUserDto)
        {
            try 
            {
                var user = await _context.tblUsers.FindAsync(id);
                if (user != null)
                {
                    user.Name = updateUserDto.Name;
                    user.Email = updateUserDto.Email;
                    user.Contact = updateUserDto.Contact;
                }
                _context.tblUsers.Update(user);
                var res = await  _context.SaveChangesAsync() > 0;

                return res ? true : false;
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
