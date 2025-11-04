using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatagoryManagement.Models
{
    public class Product
    {
        [Key]
        public int Pid { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        [ForeignKey("Category")]
        public int Cid { get; set; }
        public Category Category { get; set; }
    }
}
