using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeesController(IEmployeeService employeeService, IMapper mapper)
    {
        _employeeService = employeeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
    {
        var employees = await _employeeService.GetEmployeesAsync();
        var employeeModels = _mapper.Map<IEnumerable<EmployeeModel>>(employees);
        return Ok(employeeModels);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeModel>> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);

        if (employee == null)
            return NotFound();

        var employeeModel = _mapper.Map<EmployeeModel>(employee);
        return Ok(employeeModel);
    }

    [HttpPost]
    public async Task<ActionResult> CreateEmployee([FromBody] EmployeeModel employeeModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var employeeDTO = _mapper.Map<EmployeeDTO>(employeeModel);
        await _employeeService.CreateEmployeeAsync(employeeDTO);

        return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeDTO.EmployeeId }, employeeDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeModel employeeModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);

        if (existingEmployee == null)
            return NotFound();

        _mapper.Map(employeeModel, existingEmployee);
        await _employeeService.UpdateEmployeeAsync(_mapper.Map<EmployeeDTO>(existingEmployee));

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);

        if (existingEmployee == null)
            return NotFound();

        await _employeeService.DeleteEmployeeAsync(id);

        return NoContent();
    }
}
