using System.ComponentModel.DataAnnotations;

namespace UserBackendProject.UserDTO
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage="Name is Requierd.")]
        public string Name { get; set; }
        [Required(ErrorMessage="Name is Requierd.")]
        public string Email { get; set; }
        [Required(ErrorMessage="Name is Requierd.")]
        public string Password { get; set; }
        [Required(ErrorMessage="Name is Requierd.")]
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Users : {{ name :  {Name} , email : {Email} , password : {Password}, address : {Address} }}";
        }
    }
}
