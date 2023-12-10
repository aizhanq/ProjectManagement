using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using WebApi.Models;

namespace WebApi.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeDTO, EmployeeModel>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<ProjectDTO, ProjectModel>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
        }
    }
}
