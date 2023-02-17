using AutoMapper;
using EDCore.Data.Entities.Modals;
using EDCore.Data.Entities.ViewModels;

namespace EFCoreApp;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        CreateMap<Department, DepartmentViewModel>().ReverseMap();
    }
}
