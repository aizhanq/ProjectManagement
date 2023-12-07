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
            // Пример конфигурации для Employee
            CreateMap<EmployeeDTO, EmployeeModel>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            // Пример конфигурации для Project
            CreateMap<ProjectDTO, ProjectModel>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
        }
    }
}
