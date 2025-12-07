using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserCurd01.Dto;
using UserCurd01.Services;

namespace UserCurd01.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;
        public UserController(IUserServices s)
        {
            this._services = s;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers() 
        {
             var res = await _services.GetAllUsers();
            if (res == null)
            {
                return BadRequest(new { message = "No recourds founds..." });
            }
            else
            {
                return Ok(new { message = "success." , data = res });
            }
            
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddNewUser([FromBody] AddUserDto addUserDto) 
        {
           var res = await _services.AddNewUser(addUserDto);
            if (res)
            {
               return  Ok(new { massage = "User Added Successfully..." });
            }
            else 
            {
              return  BadRequest(new { massage= "Failed to Added."});
            }

        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto) 
        {
           var res = await  _services.UpdateUser(id, updateUserDto);
            if (res)
            {
               return  Ok(new { message = "User Updated Successfully..." });
            }
            else 
            {
                return BadRequest(new { message = "Failed to Update." });
            }

        }
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteUsersById(int id)
        {
            var res = await _services.DeleteById(id);
            if (res)
            {
                return Ok(new { message = "User Delete Successfully..." });
            }
            else 
            {
                return BadRequest(new { message = "Failed to Delete Users." });
            }
        }
    }
}
