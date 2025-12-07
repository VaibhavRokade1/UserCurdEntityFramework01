using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StapatyaUserCurd.Dto;
using StapatyaUserCurd.Services.Defination;
using System.Threading.Tasks;

namespace StapatyaUserCurd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _service;
        public ProductController(IProductServices services)
        {
            this._service = services;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto addProductDto) 
        {
           var res = await _service.AddProduct(addProductDto);

            return res ? Ok(new { massage = "Product Added Successfully..." }) : BadRequest("failed to add.");
          
        }
    }
}
