using System.Net.Mime;
using IamService.Domain.Services.Credential.Admin;
using IamService.Domain.Services.Credential.Owner;
using IamService.Domain.Services.Credential.Worker;
using IamService.Domain.Services.Users;
using IamService.Domain.Services.Users.Owner;
using IamService.Domain.Services.Users.Worker;
using IamService.Infrastructure.Pipeline.Middleware.Attributes;
using IamService.Interfaces.REST.Resource.Authentication.User;
using IamService.Interfaces.REST.Transform.Authentication.User;
using Microsoft.AspNetCore.Mvc;

namespace IamService.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationController(IAdminCommandService adminCommandService, 
    IAdminCredentialCommandService adminCredentialCommandService,
    IWorkerCommandService workerCommandService,
    IWorkerCredentialCommandService workerCredentialCommandService,
    IOwnerCommandService ownerCommandService,
    IOwnerCredentialCommandService ownerCredentialCommandService) : ControllerBase
{
    [HttpPost("sign-up-admin")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpAdmin([FromBody] SignUpUserResource resource)
    {
        try
        {
            var signUpCommand = SignUpUserCommandFromResourceAssembler.ToCommandFromResource(resource);

            await adminCommandService.Handle(signUpCommand);

            await adminCredentialCommandService.Handle(new(signUpCommand.Id, resource.Password));

            return Ok("User created correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("sign-up-worker")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpWorker([FromBody] SignUpUserResource resource)
    {
        try
        {
            var signUpCommand = SignUpUserCommandFromResourceAssembler.ToCommandFromResource(resource);

            await workerCommandService.Handle(signUpCommand);

            await workerCredentialCommandService.Handle(new(resource.Id, resource.Password));

            return Ok("User created correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("sign-up-owner")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpOwner([FromBody] SignUpUserResource resource)
    {
        try
        {
            var signUpCommand = SignUpUserCommandFromResourceAssembler.ToCommandFromResource(resource);

            await ownerCommandService.Handle(signUpCommand);

            await ownerCredentialCommandService.Handle(new(resource.Id, resource.Password));

            return Ok("User created correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        try
        {
            if (resource.RolesId is < 1 or > 3)
                throw new Exception();
            
            var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);

            dynamic? authenticatedUser = "";

            if (resource.RolesId is 1)
                authenticatedUser = await ownerCommandService.Handle(signInCommand);
            else if (resource.RolesId is 2)
                authenticatedUser = await adminCommandService.Handle(signInCommand);
            else if(resource.RolesId is 3)
                authenticatedUser = await workerCommandService.Handle(signInCommand);

            var authenticatedUserResource =
                AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser!.User,
                    authenticatedUser.Token);

            return Ok(authenticatedUserResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}