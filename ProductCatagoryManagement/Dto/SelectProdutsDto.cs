using ProductCatagoryManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatagoryManagement.Dto
{
    public class SelectProdutsDto
    {
        public int Pid { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
    }
}
