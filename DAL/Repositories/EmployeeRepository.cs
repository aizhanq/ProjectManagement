
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;

        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Project>> GetProjectsByEmployeeIdAsync(int employeeId)
        {
            var projects = await _context.EmployeeProjects
                .Where(ep => ep.EmployeeId == employeeId)
                .Select(ep => ep.Project)
                .ToListAsync();

            return projects;
        }

        public async Task AddProjectToEmployeeAsync(int employeeId, int projectId)
        {
            var employeeProject = new EmployeeProject
            {
                EmployeeId = employeeId,
                ProjectId = projectId
            };

            _context.EmployeeProjects.Add(employeeProject);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProjectFromEmployeeAsync(int employeeId, int projectId)
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
