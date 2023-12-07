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
    }
}
