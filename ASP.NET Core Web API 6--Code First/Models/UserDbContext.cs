using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API_6__Code_First.Models
{
    // DbContext is briage between c# code and  
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options) 
        {
            // DbContextOptions options carries Configration infromation such as the 
            // Connection String , Database Provider etc.

            // for the DbContext class to be able to do any useful work it need an instance
            // of the DbContextOptions class 
        }

        // uses the DbSet<User> type to define one or more properties where , < T > Represent
        // the type  of an objects that needs to be stored in the database 
        public DbSet<User> Users { get; set; }
    }
}
