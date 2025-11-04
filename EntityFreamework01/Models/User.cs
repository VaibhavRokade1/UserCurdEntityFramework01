using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFreamework01.Models
{
    public class User
    {
        [Key]
        public int  UId { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return $"User[Id {UId},Name {Name}, Email {Email}, Password {Password}]";
        }

    }
}
