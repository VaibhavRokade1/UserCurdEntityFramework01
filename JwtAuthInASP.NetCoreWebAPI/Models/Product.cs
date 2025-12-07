using System.Text.Json.Serialization;

namespace JwtAuthInASP.NetCoreWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descreption { get; set; }
        public int Cid { get; set; }
        public Category? Category { get; set; }
    }

    public class Category 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
