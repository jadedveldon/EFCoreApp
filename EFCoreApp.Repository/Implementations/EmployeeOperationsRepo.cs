using EDCore.Data.Entities.Modals;
using EFCoreApp.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Text.Json.Nodes;

namespace EFCoreApp.Repository.Implementations;
/// <summary>
/// This is a repo layer and it't the layer that interacts with the DB and performs operations on the db directly, here 2 
/// different implementations are displayed one with LINQ queries and one with Stored Procedures
/// </summary>
public class EmployeeOperationsRepo : IEmployeeOperationsRepo
{
    private readonly MasterContext context;
    public EmployeeOperationsRepo(MasterContext context)
    {
        this.context = context;
    }
    /// <summary>
    /// This takes in a employee object from the upper layers and it adds it to the db
    /// </summary>
    /// <param name="employee"></param>
    public async Task Add(Employee employee)
    {
        try
        {
            var pId = new SqlParameter($"@p{nameof(employee.Id)}", employee.Id);
            var pFirstName = new SqlParameter($"@p{nameof(employee.FirstName)}", employee.FirstName);
            var pLastName = new SqlParameter($"@p{nameof(employee.LastName)}", employee.LastName);
            var pEmail = new SqlParameter($"@p{nameof(employee.Email)}", employee.Email);
            var pDob = new SqlParameter($"@p{nameof(employee.Dob)}", employee.Dob);
            var pGender = new SqlParameter($"@p{nameof(employee.Gender)}", employee.Gender);
            var pReligion = new SqlParameter($"@p{nameof(employee.Religion)}", employee.Religion);
            var pIsActive = new SqlParameter($"@p{nameof(employee.IsActive)}", employee.IsActive);
            var pDeptid = new SqlParameter($"@p{nameof(employee.Deptid)}", employee.Deptid);
            int a = 0;
            a = await context.Database.ExecuteSqlRawAsync("EXEC InsertEmployee @pId, @pFirstName, @pLastName, @pEmail, @pDob, @pGender, @pReligion, @pIsActive, @pDeptid", parameters: new[] { pId, pFirstName, pLastName, pEmail, pDob, pGender, pReligion, pIsActive, pDeptid });
            //context.Employees.FromSql($"exec InsertEmployee {employee.Id}, {employee.FirstName}, {employee.LastName}, {employee.Email}, {employee.Dob}, {employee.Gender}, {employee.Religion}, {employee.IsActive}, {employee.Deptid}");
            //context.Employees.Add(employee);
            if (a == 0)
            {
                throw new DbUpdateException();
            }
            context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }
    /// <summary>
    /// it takes the ID of the user to be deleted and removes him from the db
    /// </summary>
    /// <param name="id"></param>
    public async Task Delete(int id)
    {
        try
        {
            //var employeeInfo = context.Employees.Find(id);
            var p0 = new SqlParameter("@p0", id);
            int a = 0;
            a = await context.Database.ExecuteSqlRawAsync("exec DeleteEmployee @p0", p0);
            if (a == 0)
            {
                throw new DbUpdateException();
            }
            //context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        context.SaveChanges();
    }
    /// <summary>
    /// this fetches employeees details using his ID to access the employee from the db
    /// </summary>
    /// <param name="id"></param>
    /// <returns>it returns a employee object which holds the data</returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<Employee> Get(int id)
    {
        var employee = await context.Employees.FromSql($"exec GetEmployee {id}").ToListAsync();
        if (employee.Count == 0)
        {
            throw new DbUpdateException();
        }
        return employee[0];


        //return employee.FirstOrDefault();
        //return context.Employees.Find(id);
    }
    /// <summary>
    /// This fetches all the tuples from the db
    /// </summary>
    /// <returns>returns a list containing all employees</returns>
    public async Task<IEnumerable<Employee>> GetAll()
    {
        var employees = await context.Employees.FromSql($"exec GetAllEmployees").ToListAsync();
        return employees;
        //return context.Employees.ToList();
    }
    /// <summary>
    /// this takes employee object as input and then using the update query it updates the db 
    /// </summary>
    /// <param name="employee"></param>
    public async Task Update(Employee employee)
    {
        try
        {
            var pId = new SqlParameter($"@p{nameof(employee.Id)}", employee.Id);
            var pFirstName = new SqlParameter($"@p{nameof(employee.FirstName)}", employee.FirstName);
            var pLastName = new SqlParameter($"@p{nameof(employee.LastName)}", employee.LastName);
            var pEmail = new SqlParameter($"@p{nameof(employee.Email)}", employee.Email);
            var pDob = new SqlParameter($"@p{nameof(employee.Dob)}", employee.Dob);
            var pGender = new SqlParameter($"@p{nameof(employee.Gender)}", employee.Gender);
            var pReligion = new SqlParameter($"@p{nameof(employee.Religion)}", employee.Religion);
            var pIsActive = new SqlParameter($"@p{nameof(employee.IsActive)}", employee.IsActive);
            var pDeptid = new SqlParameter($"@p{nameof(employee.Deptid)}", employee.Deptid);
            int a = 0;
            a = await context.Database.ExecuteSqlRawAsync("EXEC UpdateEmployee @pId, @pFirstName, @pLastName, @pEmail, @pDob, @pGender, @pReligion, @pIsActive, @pDeptid", parameters: new[] { pId, pFirstName, pLastName, pEmail, pDob, pGender, pReligion, pIsActive, pDeptid });
            if (a == 0)
            {
                throw new DbUpdateException();
            }
            //context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
