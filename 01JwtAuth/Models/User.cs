using System.ComponentModel.DataAnnotations;

namespace _01JwtAuth.Models
{
    public class User
    {
        [Key]
        public int  Id { get; set; }
        public string  Name { get; set; }
        public string  Email { get; set; }
        public string  PasswordHash { get; set; }
    }
}
