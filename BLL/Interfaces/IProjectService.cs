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
    }
}
