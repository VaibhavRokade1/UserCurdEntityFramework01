using Microsoft.EntityFrameworkCore;

namespace UserBackendProject.Models
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options) 
        { }
        public DbSet<User> Users { get; set; }                 
    }
}
