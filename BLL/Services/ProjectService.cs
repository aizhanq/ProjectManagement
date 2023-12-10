using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjectsAsync()
        {
            var projects = await _unitOfWork.Projects.GetProjectsAsync();
            return _mapper.Map<IEnumerable<ProjectDTO>>(projects);
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int projectId)
        {
            var project = await _unitOfWork.Projects.GetProjectByIdAsync(projectId);
            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task CreateProjectAsync(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            await _unitOfWork.Projects.CreateProjectAsync(project);
        }

        public async Task UpdateProjectAsync(ProjectDTO projectDTO)
        {
            var existingProject = await _unitOfWork.Projects.GetProjectByIdAsync(projectDTO.ProjectId);

            if (existingProject == null)
            {
                // Обработка ситуации, если проект с указанным ID не найден
                throw new ValidationException("Проект не найден", nameof(projectDTO.ProjectId));
            }

            // AutoMapper для копирования значений из projectDTO в existingProject
            _mapper.Map(projectDTO, existingProject);

            await _unitOfWork.Projects.UpdateProjectAsync(existingProject);
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            await _unitOfWork.Projects.DeleteProjectAsync(projectId);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesByProjectIdAsync(int projectId)
        {
            var employees = await _unitOfWork.Projects.GetEmployeesByProjectIdAsync(projectId);
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task AddEmployeeToProjectAsync(int projectId, int employeeId)
        {
            await _unitOfWork.Projects.AddEmployeeToProjectAsync(projectId, employeeId);
        }

        public async Task RemoveEmployeeFromProjectAsync(int projectId, int employeeId)
        {
            await _unitOfWork.Projects.RemoveEmployeeFromProjectAsync(projectId, employeeId);
        }
    }
}
