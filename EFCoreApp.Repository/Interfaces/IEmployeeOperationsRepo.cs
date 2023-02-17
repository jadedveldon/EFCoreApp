using EDCore.Data.Entities.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EFCoreApp.Repository.Interfaces;

public interface IEmployeeOperationsRepo 
{
    public Task<Employee> Get(int id);
    public Task<IEnumerable<Employee>> GetAll();
    public  Task Add(Employee employee);
    public Task Update(Employee employee);
    public Task Delete(int id);
}
