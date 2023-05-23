using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Requests;
using TeamworkSystem.Social.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Social.DataAccess.Common.Parameters;

namespace TeamworkSystem.Social.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendsController : ControllerBase
{
    private readonly IFriendsService _friendsService;

    public FriendsController(IFriendsService friendsService) => _friendsService = friendsService;

    [HttpGet("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(
        [FromRoute] Guid id,
        [FromQuery] FriendsParameters parameters)
    {
        var friends = await _friendsService.GetAsync(id, parameters);
        Response.Headers.Add("X-Pagination", friends.SerializeMetadata());
        return Ok(friends);
    }

    [HttpPost("{firstId:guid}/{secondId:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> AddFriendAsync(
        [FromRoute] Guid firstId,
        [FromRoute] Guid secondId)
    {
        var request = new FriendsRequest
        {
            FirstId = firstId,
            SecondId = secondId,
        };

        await _friendsService.AddToFriendsAsync(request);
        return Ok();
    }

    [HttpDelete("{firstId:guid}/{secondId:guid}")]
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

        await _friendsService.DeleteFromFriendsAsync(request);
        return Ok();
    }
}
