using System.Net.Mime;
using IamService.Domain.Model.Queries;
using IamService.Domain.Services.Users;
using IamService.Domain.Services.Users.Admin;
using IamService.Domain.Services.Users.Owner;
using IamService.Domain.Services.Users.Worker;
using IamService.Infrastructure.Pipeline.Middleware.Attributes;
using IamService.Interfaces.REST.Resource.Authentication.User;
using IamService.Interfaces.REST.Transform.Authentication.User;
using Microsoft.AspNetCore.Mvc;

namespace IamService.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController(IWorkerCommandService workerCommandService,
    IAdminCommandService adminCommandService, 
    IOwnerCommandService ownerCommandService,
    IAdminQueryService adminQueryService,
    IWorkerQueryService workerQueryService,
    IOwnerQueryService ownerQueryService) : ControllerBase
{
    
    [HttpGet("get-owner-id")]
    public async Task<IActionResult> GetOwnerById([FromQuery] int id)
    {
        try
        {
            var owner = await ownerQueryService.Handle(new GetUserByIdQuery(id));

            var ownerResource = UserResourceFromEntityAssembler.ToResourceFromEntity(owner!);

            return Ok(ownerResource);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    

    [HttpGet("get-all-admins")]
    public async Task<IActionResult> GetAdmins([FromQuery]int hotelId)
    {
        try
        {
            var admins = await adminQueryService.Handle(new GetAllUsersQuery(hotelId));

            var adminResources = admins.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
            
            return Ok(adminResources);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-all-workers")]
    public async Task<IActionResult> getAllWorkers([FromQuery]int hotelId)
    {
        try
        {
            var workers = await workerQueryService.Handle(new GetAllUsersQuery(hotelId));

            var workerResources = workers.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
            
            return Ok(workerResources);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("get-admin-count")]
    [Authorize]
    public async Task<IActionResult> GetAdminCount([FromQuery]int hotelId)
    {
        try
        {
            var admins = await adminQueryService.Handle(new GetAllUsersQuery(hotelId));

            var result = admins.Count();

            return Ok(new { count = result});
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-worker-count")]
    [Authorize]
    public async Task<IActionResult> GetWorkerCount([FromQuery] int hotelId)
    {
        try
        {
            var workers = await workerQueryService.Handle(new GetAllUsersQuery(hotelId));

            var result = workers.Count();

            return Ok(new { count = result });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("update-admin")]
    [Authorize]
    public async Task<IActionResult> UpdateAdmin([FromBody]UpdateUserResource resource)
    {
        try
        {
            var updateUserCommand = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(resource);

            await adminCommandService.Handle(updateUserCommand);
            
            return Ok("User updated correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update-owner")]
    [Authorize]
    public async Task<IActionResult> UpdateOwner([FromBody] UpdateUserResource resource)
    {
        try
        {
            var updateUserCommand = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(resource);

            await ownerCommandService.Handle(updateUserCommand);

            return Ok("User updated correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update-worker")]
    [Authorize]
    public async Task<IActionResult> UpdateWorker([FromBody] UpdateUserResource resource)
    {
        try
        {
            var updateUserCommand = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(resource);

            await workerCommandService.Handle(updateUserCommand);

            return Ok("User updated correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}