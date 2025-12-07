using Demo1UserCurd.Dto;
using Demo1UserCurd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo1UserCurd.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _services;

        public UserController(IUserService services)
        {
            _services = services;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] AddUserDto addUserDto)
        {
            try
            {
                var res = await _services.AddNewUser(addUserDto);
                return res ? Ok(new { massage = "User added successfully...." }) : BadRequest(new { massage = "Failed to add User." });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("allUsers")]
        public async Task<IActionResult> GetAllUsers() 
        {
            var userList = await  _services.GetAllUsers();

            if (userList == null)
            {
                return BadRequest(new { Massage = "Users Not Found.." });
            }
            else 
            {
                return Ok(new { Massage = "Success", data = userList });
            }
        }


        [HttpPut("UpdateById")]
        public async Task<IActionResult> UpdateUsers(int id ,  [FromBody] UpdateUserDto updateUserDto) 
        {
            var res = await _services.UpdateUserById(id, updateUserDto);
            if (res)
            {
                return Ok(new { massage = "Updated Success" });
            }
            else
                return BadRequest(new { massage="Failed to Update" });

            
        }

        [HttpDelete("deleteUserById")]
        public async Task<IActionResult> DeleteUserById(int id) 
        {
            var res = await _services.DeleteById(id);

            if (res)
            {
                return Ok(new { massage = "User Deleted Successfully..." });
            }
            else {
                return BadRequest(new { massage = "User Failed to delete. " });

            }
        }
    }
}
