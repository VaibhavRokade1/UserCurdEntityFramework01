using EmplyoeeCurdApi.Models;
using EmplyoeeCurdApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmplyoeeCurdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmplyoeeController : ControllerBase
    {
        readonly EmpRepository repo = new EmpRepository();

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (repo.AddEmp(employee))
            {
                return Ok(new { status = 200, massage = "Employee Added Successfully...!!!" });
            }
            else
                return Ok(new { status = 400, massage = "Internal server Error...!!!" });
        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            List<Employee> elist = repo.ShowEmp();
            return Ok(new { StatusCode = 200, Data = elist });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            bool isUpdated = repo.UpdateEmp(id, employee);

            if (isUpdated)
            {
                return Ok(new { status = 200, message = "Updated Successfully", data = employee });
            }
            else
            {
                return StatusCode(500, new { status = 500, message = "Internal server error" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id) 
        {
            if (repo.DeleteEmp(id))
            {
                return Ok(new { status = 200, massage = "Deleted Successfully..." });
            }
            else
                return Ok(new { status = 404, massage = "Internal server error..." });
        }
    }
}
