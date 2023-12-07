using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int employeeId);
        Task CreateEmployeeAsync(EmployeeDTO employeeDTO);
        Task UpdateEmployeeAsync(EmployeeDTO employeeDTO);
        Task DeleteEmployeeAsync(int employeeId);
    }
}

