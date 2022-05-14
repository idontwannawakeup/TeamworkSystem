using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.Identity.BusinessLogic.DTO.Requests;
using TeamworkSystem.Identity.BusinessLogic.DTO.Responses;
using TeamworkSystem.Identity.BusinessLogic.Interfaces.Services;

namespace TeamworkSystem.Identity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService) =>
        _identityService = identityService;

    [HttpPost("signIn")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<JwtResponse>> SignInAsync([FromBody] UserSignInRequest request)
    {
        var response = await _identityService.SignInAsync(request);
        return Ok(response);
    }

    [HttpPost("signUp")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<JwtResponse>> SignUpAsync([FromBody] UserSignUpRequest request)
    {
        var response = await _identityService.SignUpAsync(request);
        return Ok(response);
    }
}
