using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.Social.BusinessLogic.DTO.Requests;
using TeamworkSystem.Social.BusinessLogic.Services;

namespace TeamworkSystem.Social.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendsController : ControllerBase
{
    private readonly FriendsService _friendsService;

    public FriendsController(FriendsService friendsService) => _friendsService = friendsService;

    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        return Ok(await _friendsService.GetAsync(id));
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> AddFriendAsync([FromBody] FriendsRequest request)
    {
        await _friendsService.AddToFriendsAsync(request);
        return Ok();
    }

    [HttpDelete("/{firstId:guid}/{secondId:guid}")]
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
