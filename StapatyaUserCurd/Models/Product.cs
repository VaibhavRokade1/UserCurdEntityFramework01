using System.ComponentModel.DataAnnotations;

namespace StapatyaUserCurd.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Pid { get; set; }
        [Required]
        public string PName { get; set; }
        [Required]
        public int PPrice { get; set; }
        [Required]
        public string PDescription { get; set; }
        [Required]
        public string PCategory { get; set; }
    }
}
