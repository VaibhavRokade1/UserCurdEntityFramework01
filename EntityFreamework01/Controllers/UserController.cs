using EntityFreamework01.Dto;
using EntityFreamework01.Models;
using EntityFreamework01.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFreamework01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterDto dto)
        {
            User u = new User
            {
                Name = dto.Name,
                Email=dto.Email,
                Password=dto.Password
            };
           bool res= await service.Register(u);
            return res ? Ok("User Register Successfully") : BadRequest("User not Register");

        }
        [HttpPost("login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginDto dto)
        {
           bool res =await service.Login(dto.UserName, dto.Password);
            return res ? Ok("User login Successfully") : BadRequest("User not login");
        }
    }
}
