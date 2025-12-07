using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Demo1UserCurd.Models
{
    public class User
    {
        [Key]
        public int Uid { get; set; }
        public string  Name { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public decimal Contact { get; set; }
    }
}
