using Microsoft.EntityFrameworkCore;

namespace ProductCatagoryManagement.Models
{
    public class ProductCategoryDbContext : DbContext
    {
        public ProductCategoryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.Cid);
        }

    }
}
