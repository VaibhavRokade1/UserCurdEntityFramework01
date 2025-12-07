using System.ComponentModel.DataAnnotations;

namespace UserCurd01.Dto
{
    public class UpdateUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        
        [Required]
        public decimal Contact { get; set; }
    }
}
