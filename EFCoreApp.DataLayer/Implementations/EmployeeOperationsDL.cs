using AutoMapper;
using EDCore.Data.Entities.Modals;
using EDCore.Data.Entities.ViewModels;
using EFCoreApp.DataLayer.Interfaces;
using EFCoreApp.Repository.Interfaces;

namespace EFCoreApp.DataLayer.Implementations
{
    /// <summary>
    /// in this layer the data that is fetched from the db in the repo layer is used and operations are perfoemed on top
    /// of it like here in case we dont want the user to view everything from the DB so we have created out own view 
    /// models which are then mapped to the data models
    /// </summary>
    public class EmployeeOperationsDL : IEmployeeOperationsDL
    {
        private readonly IGenericsRepo<Employee> repo;
        private readonly IMapper mapper;

        public EmployeeOperationsDL(IGenericsRepo<Employee> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        /// <summary>
        /// calls the add function from the repo layer and here the view model which is given by the user is converted to
        /// data model and sent to lower methords
        /// </summary>
        /// <param name="employeeView"></param>
        public async Task Add(EmployeeViewModel employeeView)
        {
            Employee employee = ViewModelToModel(employeeView);
            await repo.Add(employee);
        }
        /// <summary>
        /// deletes the tuple straight while taking the id as input which is used to find the tuple
        /// </summary>
        /// <param name="id"></param>
        public async Task Delete(int id)
        {
            try
            {
                await repo.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// this function fetches the tuple from the db in form of our data model class and then that is converted to the 
        /// view model which is then converted to view model and sent to the above
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EmployeeViewModel> Get(int id)
        {
            Employee employee = await repo.Get(id);
            EmployeeViewModel viewEmployee = ModelToViewModel(employee);
            return viewEmployee;
        }
        /// <summary>
        /// fetches all the tuples from the db into a iterable list, here all the employees are fetched in the data model 
        /// then they are convertred to view model form and sent to the layer above
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            var AllEmployees = await repo.GetAll();
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            foreach (var employee in AllEmployees)
            {
                EmployeeViewModel viewEmployee = ModelToViewModel(employee);
                employees.Add(viewEmployee);
            }
            return employees;
        }
        /// <summary>
        /// takes the view model from the layer above which is then turned to data model and sent below
        /// </summary>
        /// <param name="viewEmployee"></param>
        public async Task Update(EmployeeViewModel viewEmployee)
        {
            Employee employee = ViewModelToModel(viewEmployee);
            await repo.Update(employee);
        }
        /// <summary>
        /// takes data model as input and returns view model as output
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public EmployeeViewModel ModelToViewModel(Employee employee)
        {
            //EmployeeViewModel viewEmployee = new EmployeeViewModel();
            //viewEmployee.Id = employee.Id;
            //viewEmployee.FirstName = employee.FirstName;
            //viewEmployee.LastName = employee.LastName;
            //viewEmployee.Email = employee.Email;
            //viewEmployee.Dob = employee.Dob;
            //viewEmployee.Gender = employee.Gender;
            //viewEmployee.Religion = employee.Religion;
            //viewEmployee.IsActive = employee.IsActive;
            //viewEmployee.Deptid = employee.Deptid;
            //return viewEmployee;
            return mapper.Map<EmployeeViewModel>(employee);
        }
        /// <summary>
        /// takes view model as input and returns data model as output
        /// </summary>
        /// <param name="viewEmployee"></param>
        /// <returns></returns>
        public Employee ViewModelToModel(EmployeeViewModel viewEmployee)
        {
            //Employee employee = new Employee();
            //employee.Id = viewEmployee.Id;
            //employee.FirstName = viewEmployee.FirstName;
            //employee.LastName = viewEmployee.LastName;
            //employee.Email = viewEmployee.Email;
            //employee.Dob = viewEmployee.Dob;
            //employee.Gender = viewEmployee.Gender;
            //employee.Religion = viewEmployee.Religion;
            //employee.IsActive = viewEmployee.IsActive;
            //employee.Deptid = viewEmployee.Deptid;
            //return employee;
            return mapper.Map<Employee>(viewEmployee);
        }
    }
}
