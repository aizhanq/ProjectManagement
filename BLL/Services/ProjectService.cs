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
            ValidatePriority(projectDTO.Priority);

            var project = _mapper.Map<Project>(projectDTO);
            await _unitOfWork.Projects.CreateProjectAsync(project);
        }

        public async Task UpdateProjectAsync(ProjectDTO projectDTO)
        {
            ValidatePriority(projectDTO.Priority);

            var existingProject = await _unitOfWork.Projects.GetProjectByIdAsync(projectDTO.ProjectId);

            if (existingProject == null)
                throw new ValidationException("Project not found.", nameof(projectDTO.ProjectId));

            _mapper.Map(projectDTO, existingProject);
            await _unitOfWork.Projects.UpdateProjectAsync(existingProject);
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var existingProject = await _unitOfWork.Projects.GetProjectByIdAsync(projectId);

            if (existingProject == null)
                throw new ValidationException("Project not found.", nameof(projectId));

            await _unitOfWork.Projects.DeleteProjectAsync(projectId);
        }

        private void ValidatePriority(int priority)
        {
            if (priority < 1 || priority > 5)
                throw new ValidationException("Invalid priority value. Priority must be between 1 and 5.", nameof(priority));
        }
    }
}
