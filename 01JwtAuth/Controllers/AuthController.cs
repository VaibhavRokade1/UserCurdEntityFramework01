using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01JwtAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Register")]
        public IActionResult RegisterUser() 
        {
            
        }
    }
}
