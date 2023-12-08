using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetProjectsAsync();
        Task<ProjectDTO> GetProjectByIdAsync(int projectId);
        Task CreateProjectAsync(ProjectDTO projectDTO);
        Task UpdateProjectAsync(ProjectDTO projectDTO);
        Task DeleteProjectAsync(int projectId);

        Task<IEnumerable<EmployeeDTO>> GetEmployeesByProjectIdAsync(int projectId);
        Task AddEmployeeToProjectAsync(int projectId, int employeeId);
        Task RemoveEmployeeFromProjectAsync(int projectId, int employeeId);
    }
}
