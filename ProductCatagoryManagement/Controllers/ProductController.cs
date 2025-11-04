using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatagoryManagement.Dto;
using ProductCatagoryManagement.Models;
using ProductCatagoryManagement.Repository;
using System.Threading.Tasks;

namespace ProductCatagoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepocitory _repo;
        public ProductController(IProductRepocitory repo) 
        {
            this._repo = repo;
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> Add([FromBody] AddProductDto addProductDto) 
        {
            try
            {
               var res = await _repo.AddProduct(addProductDto);
                return res ? Ok("Product Added Success...!!!") : Ok("Failed to Add Ptoduct ");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Ok("Internal Server Error....");
            }
        }

        [HttpGet("AllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var res = await _repo.GetAllProduct();
                return res != null ? Ok(new { status = 200 , Data = res }) : Ok("Failed to Get Ptoducts ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Ok("Internal Server Error....");
            }
        }

        [HttpPut("product/{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, UpdateProductDto updateProductDto) 
        {
            try
            {
                var res = await _repo.UpdateProduct(id, updateProductDto);
                return res ? Ok(new { status = 200 , Data = updateProductDto  }) : BadRequest("Something went wrong...");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Ok(new { Status = 505, Massage = "Internal Server Error...!!!" });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            try
            {
               var res = await _repo.DeleteProduct(id);
                return res ? Ok(new { status = 200 , massage = "User Deleted Successfully...!!!" }) : BadRequest("Something Went wrong...");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Ok("Internal Server Error....");
            }
        }

        [HttpGet("ProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id) 
        {
            try
            {
                var product = await _repo.GetProductById(id);
                if (product == null) return Ok("Product Not found...");

                return Ok(new { Product  = product});

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest("Internal Server Error...");
            }
        }
    }
}
