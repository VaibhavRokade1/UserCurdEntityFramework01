using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserBackendProject.Models;
using UserBackendProject.Services;
using UserBackendProject.UserDTO;

namespace UserBackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserServices _userServices;

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }


        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser([FromBody] UserRegisterDTO user)
        {
            var res = await _userServices.Register(user);
            if (res)
            {
                return Ok(new { status = 200, massage = "User Register Successfully..." });
            }
            else
                return Ok(new { status = 400 , massage = "Internal Server Error..." });


        }
    }

}
