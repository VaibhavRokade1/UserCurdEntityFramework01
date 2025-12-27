using _01JwtAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace _01JwtAuth.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }
}
