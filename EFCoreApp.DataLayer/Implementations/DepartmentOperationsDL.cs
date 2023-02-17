using AutoMapper;
using EDCore.Data.Entities.Modals;
using EDCore.Data.Entities.ViewModels;
using EFCoreApp.DataLayer.Interfaces;
using EFCoreApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataLayer.Implementations;

public class DepartmentOperationsDL : IDepartmentOperationsDL
{
    private readonly IGenericsRepo<Department> repo;
    private readonly IMapper mapper;
    public DepartmentOperationsDL(IGenericsRepo<Department> repo, IMapper mapper)
    {
        this.repo = repo;
        this.mapper = mapper;
    }
    public async Task Add(DepartmentViewModel viewDepartment)
    {
        Department department = ViewModelToModel(viewDepartment);
        await repo.Add(department);
    }

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

    public async Task<DepartmentViewModel> Get(int id)
    {
        Department department = await repo.Get(id);
        DepartmentViewModel viewDepartment = ModelToViewModel(department);
        return viewDepartment;
    }

    public async Task<IEnumerable<DepartmentViewModel>> GetAll()
    {
        var AllDepartments = await repo.GetAll();
        List<DepartmentViewModel> departments = new List<DepartmentViewModel>();
        foreach (var department in AllDepartments)
        {
            DepartmentViewModel viewDepartment = ModelToViewModel(department);
            departments.Add(viewDepartment);
        }
        return departments;
    }

    public async Task Update(DepartmentViewModel viewDepartment)
    {
        Department department = ViewModelToModel(viewDepartment);
        await repo.Update(department);
    }
    public Department ViewModelToModel(DepartmentViewModel viewDepartment)
    {
        return mapper.Map<Department> (viewDepartment);
    }
    public DepartmentViewModel ModelToViewModel(Department department)
    {
        return mapper.Map<DepartmentViewModel> (department);
    }
}
