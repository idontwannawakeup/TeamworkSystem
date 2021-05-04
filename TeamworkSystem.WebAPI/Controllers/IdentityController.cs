using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;

namespace TeamworkSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identityService;

        [HttpPost("signIn")]
        public async Task<ActionResult<JwtResponse>> SignInAsync(
            [FromBody] UserSignInRequest request)
        {
            try
            {
                var response = await identityService.SignInAsync(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        public IdentityController(IIdentityService identityService) =>
            this.identityService = identityService;
    }
}
