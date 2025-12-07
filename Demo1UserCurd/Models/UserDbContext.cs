using Microsoft.EntityFrameworkCore;

namespace Demo1UserCurd.Models
{
    public class UserDbContext  : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> tblDemo1User { get; set; }
    }
}
