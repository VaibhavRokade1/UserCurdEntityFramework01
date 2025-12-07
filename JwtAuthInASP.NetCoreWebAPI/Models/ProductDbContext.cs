using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JwtAuthInASP.NetCoreWebAPI.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions option) : base(option)
        {
            
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.Cid);

            base.OnModelCreating(modelBuilder);
        }

    }
}
