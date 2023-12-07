using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationContext _context;

        public ProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _context.Projects.FindAsync(projectId);
        }

        public async Task CreateProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
