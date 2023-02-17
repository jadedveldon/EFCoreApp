using EDCore.Data.Entities.ViewModels;

namespace EFCoreApp.DataLayer.Interfaces;

public interface IDepartmentOperationsDL
{
    public Task<DepartmentViewModel> Get(int id);
    public Task<IEnumerable<DepartmentViewModel>> GetAll();
    public Task Add(DepartmentViewModel viewDepartment);
    public Task Update(DepartmentViewModel viewDepartment);
    public Task Delete(int id);
}
