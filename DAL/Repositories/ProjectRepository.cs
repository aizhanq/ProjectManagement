using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Employee>> GetEmployeesByProjectIdAsync(int projectId)
        {
            var employees = await _context.EmployeeProjects
                .Where(ep => ep.ProjectId == projectId)
                .Select(ep => ep.Employee)
                .ToListAsync();

            return employees;
        }

        public async Task AddEmployeeToProjectAsync(int projectId, int employeeId)
        {
            var employeeProject = new EmployeeProject
            {
                EmployeeId = employeeId,
                ProjectId = projectId
            };

            _context.EmployeeProjects.Add(employeeProject);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveEmployeeFromProjectAsync(int projectId, int employeeId)
        {
            var employeeProject = await _context.EmployeeProjects
                .Where(ep => ep.EmployeeId == employeeId && ep.ProjectId == projectId)
                .FirstOrDefaultAsync();

            if (employeeProject != null)
            {
                _context.EmployeeProjects.Remove(employeeProject);
                await _context.SaveChangesAsync();
            }
        }
    }
}
