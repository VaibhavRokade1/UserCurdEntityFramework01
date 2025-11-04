using System.ComponentModel.DataAnnotations;

namespace UserBackendProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"User {{ id : {Id} , Name : {Name} , Email : {Email} , Password : {Password} , Address : {Address} }}";
        }
    }
}
