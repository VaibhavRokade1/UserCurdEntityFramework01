using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersWebApi.Models;

namespace UsersWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Get")]
        public string Get()
        {

            return "Ram Ram";
        }
        [HttpPost("add")]
        public ActionResult AddUser([FromBody] User ob)
        {
            return Ok(ob);
        }

        [HttpPut("update/1")]
        public ActionResult Update([FromBody] User ob) 
        {
            return Ok(ob);
        }

        
    }
}
