using EDCore.Data.Entities.Modals;
using EDCore.Data.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
