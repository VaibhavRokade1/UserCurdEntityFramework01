using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendRevission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GetAllUsers")]
        public IActionResult GetUsers() {
            return Ok(new { massage = "Users get successufully..." });
        }
    }
}
