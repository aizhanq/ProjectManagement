using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;

    public ProjectsController(IProjectService projectService, IMapper mapper)
    {
        _projectService = projectService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectModel>>> GetProjects()
    {
        var projects = await _projectService.GetProjectsAsync();
        var projectModels = _mapper.Map<IEnumerable<ProjectModel>>(projects);
        return Ok(projectModels);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectModel>> GetProjectById(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);

        if (project == null)
            return NotFound();

        var projectModel = _mapper.Map<ProjectModel>(project);
        return Ok(projectModel);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProject([FromBody] ProjectModel projectModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var projectDTO = _mapper.Map<ProjectDTO>(projectModel);
        await _projectService.CreateProjectAsync(projectDTO);

        return CreatedAtAction(nameof(GetProjectById), new { id = projectDTO.ProjectId }, projectDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProject(int id, [FromBody] ProjectModel projectModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingProject = await _projectService.GetProjectByIdAsync(id);

        if (existingProject == null)
            return NotFound();

        _mapper.Map(projectModel, existingProject);
        await _projectService.UpdateProjectAsync(_mapper.Map<ProjectDTO>(existingProject));

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProject(int id)
    {
        var existingProject = await _projectService.GetProjectByIdAsync(id);

        if (existingProject == null)
            return NotFound();

        await _projectService.DeleteProjectAsync(id);

        return NoContent();
    }
}
