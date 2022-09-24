using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;

namespace TeamworkSystem.WebAPI.Controllers;

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
