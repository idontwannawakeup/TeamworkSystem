using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.EventBus.Messages;
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
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public UsersController(
        IUsersService usersService,
        IPublishEndpoint publishEndpoint,
        IMapper mapper)
    {
        _usersService = usersService;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
    }

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
        var updatedUser = await _usersService.UpdateAsync(request);
        var eventMessage = _mapper.Map<UserChangedEvent>(updatedUser);
        await _publishEndpoint.Publish(eventMessage);
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

    [HttpPost("avatar")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> SetAvatarForUserAsync([FromForm] UserAvatarRequest request)
    {
        var avatar = await _usersService.SetAvatarForUserAsync(request);
        await _publishEndpoint.Publish(new UserAvatarChangedEvent
        {
            UserId = request.UserId,
            Avatar = avatar
        });

        return Ok();
    }
}
