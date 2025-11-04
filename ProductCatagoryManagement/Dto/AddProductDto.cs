using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatagoryManagement.Dto
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Cid { get; set; }
    }
}
