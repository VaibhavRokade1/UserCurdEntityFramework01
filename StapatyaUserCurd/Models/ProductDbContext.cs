using Microsoft.EntityFrameworkCore;

namespace StapatyaUserCurd.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Product> Product { get; set; }


    }
}
