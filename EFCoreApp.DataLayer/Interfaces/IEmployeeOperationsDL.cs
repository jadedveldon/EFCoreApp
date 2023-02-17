using EDCore.Data.Entities.ViewModels;

namespace EFCoreApp.DataLayer.Interfaces
{
    public interface IEmployeeOperationsDL
    {
        public Task<EmployeeViewModel> Get(int id);
        public Task<IEnumerable<EmployeeViewModel>> GetAll();
        public Task Add(EmployeeViewModel viewEmployee);
        public Task Update(EmployeeViewModel viewEmployee);
        public Task Delete(int id);
    }
}
