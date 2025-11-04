using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductCatagoryManagement.Models
{
    public class Category
    {
        [Key]
        public  int Cid { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
