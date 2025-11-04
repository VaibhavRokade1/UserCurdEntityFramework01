using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatagoryManagement.Dto;
using ProductCatagoryManagement.Repository;
using System.Threading.Tasks;

namespace ProductCatagoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repo)
        {
            this._repo = repo;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> GetAllCategory([FromBody] AddCategoryDto addCategoryDto)
        {
            try
            {
                var res = await _repo.AddCategory(addCategoryDto);
                return res ? Ok(new { massage = "Category added Successfully..." }) : BadRequest("Failed to add category...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Ok(new { Massage = "Internal Server Error..." });
            }
        }

        [HttpGet("getAllCaegory")]
        public IActionResult GetAllCategory()
        {
            try
            {
                var res = _repo.GetAllCategory();
                return res != null ? Ok(new { massage = "Success", data = res }) : BadRequest("Failed to fetch category...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Ok(new { Massage = "Internal Server Error..." });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> ModifyCat([FromRoute ] int id , [FromBody] UpdateCategoryDto updateCategoryDto) 
        {
            
                try
                {
                      var res = await _repo.UpdateCategory(id, updateCategoryDto);
                return res ? Ok(new { massage = "Data Updated Successfully...", Data = updateCategoryDto }) : BadRequest("Failed to update..."); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    return BadRequest("Internal Server Error...!!!");
                }
            
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remove( [FromRoute] int  id ) 
        {
                try
                {
                  var res = await _repo.DeleteCategory(id);
                return res ? Ok(new { massage = "Data Deleted Successfully..." }) : BadRequest("Failed to update...");
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                return Ok("Internal Server Error...");
                }   
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var category = await _repo.GetCategoryById(id);
                if (category == null) return Ok("Category Not found...");

                return Ok(new { Category = category });

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
