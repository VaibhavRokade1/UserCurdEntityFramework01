using backendRevission.Models;
using Microsoft.EntityFrameworkCore;

namespace backendRevission.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
