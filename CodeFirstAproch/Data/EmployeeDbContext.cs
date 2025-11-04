using CodeFirstAproch.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstAproch.Data
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> op) : base(op) { }
       
        public DbSet<Emp> Emp { get; set; }
    }
}
