using System.ComponentModel.DataAnnotations;

namespace UserBackendProject.UserDTO
{
    public class UserUpdateDTO
    {
        [Required(ErrorMessage ="Name is Required.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Users : {{ name :  {Name} , email : {Email} , address : {Address} }}";
        }
    }
}
