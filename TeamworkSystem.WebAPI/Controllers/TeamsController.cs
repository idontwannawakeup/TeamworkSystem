using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;
using TeamworkSystem.WebAPI.Extensions;

namespace TeamworkSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamsService _teamsService;

    public TeamsController(ITeamsService teamsService) => _teamsService = teamsService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedList<TeamResponse>>> GetAsync(
        [FromQuery] TeamsParameters parameters)
    {
        try
        {
            var teams = await _teamsService.GetAsync(parameters);
            Response.Headers.Add("X-Pagination", teams.SerializeMetadata());
            return Ok(teams);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TeamResponse>> GetByIdAsync([FromRoute] int id) =>
        Ok(await _teamsService.GetByIdAsync(id));

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertAsync([FromBody] TeamRequest request)
    {
        try
        {
            await _teamsService.InsertAsync(request);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateAsync([FromBody] TeamRequest request)
    {
        try
        {
            await _teamsService.UpdateAsync(request);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpPost("avatar")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> SetAvatarForTeamAsync([FromForm] TeamAvatarRequest request)
    {
        try
        {
            await _teamsService.SetAvatarForTeamAsync(request);
            return Ok();
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new { e.Message });
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _teamsService.DeleteAsync(id);
            return Ok();
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new { e.Message });
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpPost("members")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> AddMemberAsync([FromBody] TeamMemberRequest request)
    {
        try
        {
            await _teamsService.AddMemberAsync(request);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("members/{teamId}/{memberId}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteMemberAsync([FromRoute] int teamId,
                                                      [FromRoute] string memberId)
    {
        try
        {
            var request = new TeamMemberRequest { TeamId = teamId, UserId = memberId };
            await _teamsService.DeleteMemberAsync(request);
            return Ok();
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new { e.Message });
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}
