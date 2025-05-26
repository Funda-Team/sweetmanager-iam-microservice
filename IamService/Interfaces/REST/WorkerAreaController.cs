using IamService.Domain.Model.Queries;
using IamService.Domain.Services.Roles;
using IamService.Interfaces.REST.Resource.Assignments;
using IamService.Interfaces.REST.Resource.Authentication.Role;
using IamService.Interfaces.REST.Transform.Authentication.Role;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IamService.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Infrastructure.Pipeline.Middleware.Attributes.Authorize]
[Produces(MediaTypeNames.Application.Json)]
public class WorkerAreaController(IWorkerAreaCommandService workerAreaCommandService,
    IWorkerAreaQueryService workerAreaQueryService) : ControllerBase
{
    [HttpPost("create-worker-area")]
    public async Task<IActionResult> CreateWorkerArea([FromBody] CreateWorkAreaResource resource)
    {
        try
        {
            var createWorkAreaCommand =
                CreateWorkAreaCommandFromResourceAssembler.ToCommandFromResource(resource);

            await workerAreaCommandService.Handle(createWorkAreaCommand);

            return Ok("Worker Area created correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-all-worker-areas")]
    public async Task<IActionResult> GetAllWorkerAreas([FromQuery] int hotelId)
    {
        try
        {
            var workerAreas = await workerAreaQueryService.Handle(new GetAllWorkerAreasByHotelIdQuery(hotelId));

            var workerAreasResource = workerAreas.Select(WorkAreaResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(workerAreasResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-worker-area-by-name")]
    public async Task<IActionResult> GetWorkerAreaByName([FromQuery] string name, [FromQuery] int hotelId)
    {
        try
        {
            var workerArea =
                await workerAreaQueryService.Handle(
                    new GetWorkerAreaByNameAndHotelIdQuery(name, hotelId));

            if (workerArea is null)
                return BadRequest("Any work area has the given name");
            
            var workerAreaResource = WorkAreaResourceFromEntityAssembler.ToResourceFromEntity(workerArea);

            return Ok(workerAreaResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-worker-areas-by-worker-id")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetWorkerAreasByWorkerId([FromQuery] int workerId)
    {
        try
        {
            var workerArea = await workerAreaQueryService.Handle(new GetWorkerAreaByWorkerId(workerId));

            return !string.IsNullOrEmpty(workerArea) ? Ok(new SubRoleResource(workerArea)) : Ok("Empty");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
}