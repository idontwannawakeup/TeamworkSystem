using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.Identity.BusinessLogic.DTO.Requests;
using TeamworkSystem.Identity.BusinessLogic.DTO.Responses;
using TeamworkSystem.Identity.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Identity.DataAccess.Parameters;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Identity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService) => _usersService = usersService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedList<UserResponse>>> GetAsync(
        [FromQuery] UsersParameters parameters)
    {
        var users = await _usersService.GetAsync(parameters);
        Response.Headers.Add("X-Pagination", users.SerializeMetadata());
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserResponse>> GetByIdAsync([FromRoute] Guid id) =>
        Ok(await _usersService.GetByIdAsync(id));

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateAsync([FromBody] UserRequest request)
    {
        await _usersService.UpdateAsync(request);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _usersService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("friends/{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedList<UserResponse>>> GetFriendsAsync(
        [FromRoute] Guid id,
        [FromQuery] UsersParameters parameters)
    {
        var friends = await _usersService.GetFriendsAsync(id, parameters);
        Response.Headers.Add("X-Pagination", friends.SerializeMetadata());
        return Ok(friends);
    }

    [HttpPost("avatar")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> SetAvatarForUserAsync([FromForm] UserAvatarRequest request)
    {
        await _usersService.SetAvatarForUserAsync(request);
        return Ok();
    }

    [HttpPost("friends")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> AddFriendAsync([FromBody] FriendsRequest request)
    {
        await _usersService.AddFriendAsync(request);
        return Ok();
    }

    [HttpDelete("friends/{firstId:guid}/{secondId:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteFriendAsync(
        [FromRoute] Guid firstId,
        [FromRoute] Guid secondId)
    {
        var request = new FriendsRequest
        {
            FirstId = firstId,
            SecondId = secondId,
        };

        await _usersService.DeleteFriendAsync(request);
        return Ok();
    }
}
