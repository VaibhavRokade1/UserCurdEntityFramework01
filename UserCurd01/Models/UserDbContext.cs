using Microsoft.EntityFrameworkCore;

namespace UserCurd01.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions option) : base(option)
        {
            
        }

        public DbSet<User> tblUsers { get; set; }
    }
}
