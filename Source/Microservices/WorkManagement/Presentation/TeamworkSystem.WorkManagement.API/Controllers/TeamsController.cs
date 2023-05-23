using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.EventBus.Messages.RecentEvents;
using TeamworkSystem.Shared.Exceptions;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.AddMember;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.CreateTeam;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.DeleteMember;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.DeleteTeam;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.SetTeamAvatar;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.UpdateTeam;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Queries.GetTeamById;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Queries.GetTeamMembers;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Queries.GetTeams;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IPublishEndpoint _publishEndpoint;

    public TeamsController(IMediator mediator, IPublishEndpoint publishEndpoint)
    {
        _mediator = mediator;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedList<TeamResponse>>> GetAsync(
        [FromQuery] TeamsParameters parameters)
    {
        try
        {
            var query = new GetTeamsQuery { Parameters = parameters };
            var teams = await _mediator.Send(query);
            Response.Headers.Add("X-Pagination", teams.SerializeMetadata());
            return Ok(teams);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TeamResponse>> GetByIdAsync([FromRoute] Guid id)
    {
        var query = new GetTeamByIdQuery { Id = id };
        var team = await _mediator.Send(query);

        var authorization = HttpContext.Request.Headers.Authorization;
        if (AuthenticationHeaderValue.TryParse(authorization, out var authorizationHeaderValue))
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(
                authorizationHeaderValue.Parameter);

            var userId = Guid.Parse(
                token.Claims.First(claim => claim.Type == ClaimTypes.Authentication).Value);

            await _publishEndpoint.Publish(new TeamAddedToRecentEvent
            {
                UserId = userId,
                TeamId = team.Id
            });
        }

        return Ok(team);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertAsync([FromBody] CreateTeamCommand command)
    {
        try
        {
            await _mediator.Send(command);
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
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateTeamCommand command)
    {
        try
        {
            await _mediator.Send(command);
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
    public async Task<ActionResult> SetAvatarForTeamAsync([FromForm] SetTeamAvatarCommand command)
    {
        try
        {
            await _mediator.Send(command);
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

    [HttpDelete("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
    {
        try
        {
            var command = new DeleteTeamCommand { Id = id };
            await _mediator.Send(command);
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

    [HttpGet("{teamId:guid}/members")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMembersAsync([FromRoute] Guid teamId)
    {
        var query = new GetTeamMembersQuery { TeamId = teamId };
        var members = await _mediator.Send(query);
        return Ok(members);
    }

    [HttpPost("members")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> AddMemberAsync([FromBody] AddMemberCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }

    [HttpDelete("members/{teamId:guid}/{memberId:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteMemberAsync(
        [FromRoute] Guid teamId,
        [FromRoute] Guid memberId)
    {
        try
        {
            var command = new DeleteMemberCommand { TeamId = teamId, UserId = memberId };
            await _mediator.Send(command);
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
