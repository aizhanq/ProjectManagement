using Microsoft.AspNetCore.Mvc;
using BLL.DTO;
using BLL.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            await _employeeService.CreateEmployeeAsync(employeeDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            employeeDTO.EmployeeId = id;
            await _employeeService.UpdateEmployeeAsync(employeeDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            await _employeeService.DeleteEmployeeAsync(id);

            return Ok();
        }

        [HttpGet("{employeeId}/projects")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectsByEmployeeId(int employeeId)
        {
            var projects = await _employeeService.GetProjectsByEmployeeIdAsync(employeeId);
            return Ok(projects);
        }

        [HttpPost("{employeeId}/projects/{projectId}")]
        public async Task<ActionResult> AddProjectToEmployee(int employeeId, int projectId)
        {
            await _employeeService.AddProjectToEmployeeAsync(employeeId, projectId);
            return Ok();
        }

        [HttpDelete("{employeeId}/projects/{projectId}")]
        public async Task<ActionResult> RemoveProjectFromEmployee(int employeeId, int projectId)
        {
            await _employeeService.RemoveProjectFromEmployeeAsync(employeeId, projectId);
            return Ok();
        }
    }
}
