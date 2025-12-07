using System.ComponentModel.DataAnnotations;

namespace StapatyaUserCurd.Dto
{
    public class UpdateProductDto
    {
        public string PName { get; set; }
        public int PPrice { get; set; }
        public string PDescription { get; set; }
    }
}
