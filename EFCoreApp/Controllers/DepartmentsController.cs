using EDCore.Data.Entities.Modals;
using EDCore.Data.Entities.ViewModels;
using EFCoreApp.DataLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentOperationsDL departmentDL;
        public DepartmentsController(IDepartmentOperationsDL departmentDL)
        {
            this.departmentDL = departmentDL;
        }
        //GET
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var department = await departmentDL.Get(id);
                return Ok(department);
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
        //GET ALL
        [HttpGet]
        public async Task<IEnumerable<DepartmentViewModel>> GetAll()
        {
            try
            {
                return await departmentDL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartmentViewModel viewDepartment)
        {
            try
            {
                // TODO: Get the department Id back from this method
                await departmentDL.Add(viewDepartment);
                var departmentId = viewDepartment.Id;
                //return the department Id
                return CreatedAtAction(nameof(Get), new { Id = departmentId }, viewDepartment);
            }
            catch (DbUpdateException ex)
            {
                return Problem(statusCode: 400, title: $"Department not added {ex.Message}", detail: "The Department's details were not added in the Database");
            }
            catch (Exception ex)
            {
                return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] DepartmentViewModel viewDepartment)
        {
            try
            {
                await departmentDL.Update(viewDepartment);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return Problem(statusCode: 400, title: "Department not updated", detail: "The Department's details were not updated in the Database");
            }
            catch (Exception ex)
            {
                return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await departmentDL.Delete(id);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return Problem(statusCode: 400, title: "Department not Deleted", detail: "The department's details were not removed from the Database");
            }
            catch (Exception ex)
            {
                return Problem(statusCode: 400, title: ex.Message, detail: ex.StackTrace);
            }
        }
    }
}
