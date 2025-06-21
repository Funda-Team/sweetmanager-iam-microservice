using IamService.Domain.Model.Aggregates;
using IamService.Interfaces.REST.Transform.Authentication.User;
using Microsoft.AspNetCore.Mvc;

namespace IamService.Interfaces.ACL.Controllers
{
    [ApiController]
    [Route("api/v1/facade/iam")]
    public class IamContextFacadeController(IIamContextFacade iamContextFacade) : ControllerBase
    {
        [HttpGet("admins/{adminId:int}")]
        public async Task<IActionResult> FetchAdminByUserId(int adminId)
        {
            try
            {
                var admin = await iamContextFacade.FetchAdminByUserId(adminId);

                if (admin is null)
                    return StatusCode(StatusCodes.Status500InternalServerError);

                var adminResource = UserResourceFromEntityAssembler.ToResourceFromEntity(admin);

                return Ok(adminResource);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("owners/{ownerId:int}")]
        public async Task<IActionResult> FetchOwnerByUserId(int ownerId)
        {
            try
            {
                var owner = await iamContextFacade.FetchOwnerByUserId(ownerId);

                if (owner is null)
                    return StatusCode(StatusCodes.Status500InternalServerError);

                var ownerResource = UserResourceFromEntityAssembler.ToResourceFromEntity(owner);

                return Ok(ownerResource);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("workers/{workerId:int}")]
        public async Task<IActionResult> FetchWorkerByUserId(int workerId)
        {
            try
            {
                var worker = await iamContextFacade.FetchWorkerByUserId(workerId);

                if (worker is null)
                    return StatusCode(StatusCodes.Status500InternalServerError);

                var workerResource = UserResourceFromEntityAssembler.ToResourceFromEntity(worker);

                return Ok(workerResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
