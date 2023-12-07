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
    }
}
