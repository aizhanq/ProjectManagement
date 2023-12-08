using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync()
        {
            var employees = await _unitOfWork.Employees.GetEmployeesAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _unitOfWork.Employees.GetEmployeeByIdAsync(employeeId);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task CreateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            await _unitOfWork.Employees.CreateEmployeeAsync(employee);
        }

        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            await _unitOfWork.Employees.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            await _unitOfWork.Employees.DeleteEmployeeAsync(employeeId);
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjectsByEmployeeIdAsync(int employeeId)
        {
            var projects = await _unitOfWork.Employees.GetProjectsByEmployeeIdAsync(employeeId);
            return _mapper.Map<IEnumerable<ProjectDTO>>(projects);
        }

        public async Task AddProjectToEmployeeAsync(int employeeId, int projectId)
        {
            await _unitOfWork.Employees.AddProjectToEmployeeAsync(employeeId, projectId);
        }

        public async Task RemoveProjectFromEmployeeAsync(int employeeId, int projectId)
        {
            await _unitOfWork.Employees.RemoveProjectFromEmployeeAsync(employeeId, projectId);
        }
    }
}
