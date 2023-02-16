using AutoMapper;
using System.Net;
using EDCore.Data.Entities.Modals;
using EDCore.Data.Entities.ViewModels;

namespace EFCoreApp;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Employee, EmployeeViewModel>().ReverseMap();
    }
}
