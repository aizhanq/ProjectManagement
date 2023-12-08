using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int projectId);
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int projectId);

        Task<IEnumerable<Employee>> GetEmployeesByProjectIdAsync(int projectId);
        Task AddEmployeeToProjectAsync(int projectId, int employeeId);
        Task RemoveEmployeeFromProjectAsync(int projectId, int employeeId);
    }
}
