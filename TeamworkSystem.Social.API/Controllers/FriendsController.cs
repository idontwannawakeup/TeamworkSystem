using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.Social.BusinessLogic.Services;

namespace TeamworkSystem.Social.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendsController : ControllerBase
{
    private readonly FriendsService _friendsService;

    public FriendsController(FriendsService friendsService) => _friendsService = friendsService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        return Ok(await _friendsService.GetAsync(id));
    }
}
