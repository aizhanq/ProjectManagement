using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int employeeId);

        Task<IEnumerable<Project>> GetProjectsByEmployeeIdAsync(int employeeId);
        Task AddProjectToEmployeeAsync(int employeeId, int projectId);
        Task RemoveProjectFromEmployeeAsync(int employeeId, int projectId);
    }
}
