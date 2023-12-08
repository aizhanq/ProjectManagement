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

        Task<IEnumerable<ProjectDTO>> GetProjectsByEmployeeIdAsync(int employeeId);
        Task AddProjectToEmployeeAsync(int employeeId, int projectId);
        Task RemoveProjectFromEmployeeAsync(int employeeId, int projectId);
    }
}

