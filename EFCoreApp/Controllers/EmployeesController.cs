using EDCore.Data.Entities.ViewModels;
using EFCoreApp.DataLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// calling the functions from data layer and they are mapped to their relavent end points
        /// </summary>
        /// <returns></returns>
        private readonly IEmployeeOperationsDL employeeDL;
        public EmployeesController(IEmployeeOperationsDL employeeDL)
        {
            this.employeeDL = employeeDL;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            return await employeeDL.GetAll();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var employee = await employeeDL.Get(id);
                return Ok(employee);
            }
            catch (DbUpdateException)
            {
                return Problem(statusCode: 404, title: "ID not found", detail: "ID entered does not exist in the Database");
            }
            catch (Exception ex)
            {
                return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
            }

        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeViewModel viewEmployee)
        {
            try
            {
                // TODO: Get the employee Id back from this method
                await employeeDL.Add(viewEmployee);
                var employeeId = viewEmployee.Id;
                //return the employee Id
                return CreatedAtAction(nameof(Get), new { Id = employeeId }, viewEmployee);
            }
            catch (DbUpdateException)
            {
                return Problem(statusCode: 400, title: "Employee not added", detail: "The employee's details were not added in the Database");
            }
            catch (Exception ex)
            {
                return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] EmployeeViewModel viewEmployee)
        {
            try
            {
                await employeeDL.Update(viewEmployee);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return Problem(statusCode: 400, title: "Employee not updated", detail: "The employee's details were not updated in the Database");
            }
            catch (Exception ex)
            {
                return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await employeeDL.Delete(id);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return Problem(statusCode: 400, title: "Employee not Deleted", detail: "The employee's details were not removed from the Database");
            }
            catch (Exception ex)
            {
                return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
            }
        }
    }
}
