using JwtAuthInASP.NetCoreWebAPI.Dto;
using JwtAuthInASP.NetCoreWebAPI.Services.Defination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JwtAuthInASP.NetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }
        [HttpPost("AddProduct")]

        public async Task<IActionResult> AddNewProduct(AddProductDto addProductDto) 
        {
            var res = await _services.AddProduct(addProductDto);
            if (res)
            {
                return Ok(new { message = "Product Added Successfully." });
            }
            else 
            {
                return BadRequest(new { message = "Failded to added." });
            }
        }


    }
}
