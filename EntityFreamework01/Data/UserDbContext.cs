using EntityFreamework01.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFreamework01.Data
{
    public class UserDbContext :DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> op): base(op) { }

        public DbSet<User> TblUser { get; set; }

    }
}
