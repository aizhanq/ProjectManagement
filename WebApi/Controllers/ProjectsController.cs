using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.DTO;
using BLL.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {
            var projects = await _projectService.GetProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject([FromBody] ProjectDTO projectDTO)
        {
            await _projectService.CreateProjectAsync(projectDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, [FromBody] ProjectDTO projectDTO)
        {
            var existingProject = await _projectService.GetProjectByIdAsync(id);

            if (existingProject == null)
            {
                return NotFound();
            }

            projectDTO.ProjectId = id;
            await _projectService.UpdateProjectAsync(projectDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var existingProject = await _projectService.GetProjectByIdAsync(id);

            if (existingProject == null)
            {
                return NotFound();
            }

            await _projectService.DeleteProjectAsync(id);

            return Ok();
        }

        [HttpGet("{projectId}/employees")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByProjectId(int projectId)
        {
            var employees = await _projectService.GetEmployeesByProjectIdAsync(projectId);
            return Ok(employees);
        }

        [HttpPost("{projectId}/employees/{employeeId}")]
        public async Task<ActionResult> AddEmployeeToProject(int projectId, int employeeId)
        {
            await _projectService.AddEmployeeToProjectAsync(projectId, employeeId);
            return Ok();
        }

        [HttpDelete("{projectId}/employees/{employeeId}")]
        public async Task<ActionResult> RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            await _projectService.RemoveEmployeeFromProjectAsync(projectId, employeeId);
            return Ok();
        }
    }
}
