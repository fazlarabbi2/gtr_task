using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IGenericRepository<Employee> repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await repo.ListAllAsync();
            return StatusCode(200, employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var employee = await repo.GetByIdAsync(id);

            if (employee == null) return StatusCode(404);

            return StatusCode(200, employee);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Employee employee)
        {
            repo.Add(employee);

            if (await repo.SaveAllAsync())
            {
                return CreatedAtAction("GetEmployeeById", new { id = employee.Id }, employee);
            }

            return StatusCode(400, "Problem Creating an Employee");
            //return BadRequest("Problem Creating an Employee");
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (employee.Id != id || !EmployeeExits(id))
            {
                return StatusCode(404, "Problem Updating the Employee");
            }

            repo.Update(employee);

            if (await repo.SaveAllAsync())
            {
                return StatusCode(204);
            }

            return StatusCode(400, "Problem Updating the Employee");
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await repo.GetByIdAsync(id);

            if (employee == null) return NotFound();

            repo.Remove(employee);

            if (await repo.SaveAllAsync())
            {
                return StatusCode(204);
            }

            return StatusCode(400, "Problem Deleting the Employee");
        }


        private bool EmployeeExits(int id)
        {
            return repo.Exists(id);
        }
    }
}
