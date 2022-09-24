using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using TeamworkSystem.Content.Application.Common.Responses;
using TeamworkSystem.Content.Application.Features.Recent.Queries.GetRecentProjects;
using TeamworkSystem.Content.Application.Features.Recent.Queries.GetRecentTeams;
using TeamworkSystem.Content.Application.Features.Recent.Queries.GetRecentTickets;
using TeamworkSystem.Content.Domain.Enums;

namespace TeamworkSystem.Content.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecentController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IDistributedCache _cache;

    public RecentController(IMediator mediator, IDistributedCache cache)
    {
        _mediator = mediator;
        _cache = cache;
    }

    [HttpGet("projects/{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRecentProjectsAsync([FromRoute] Guid id)
    {
        var cacheConnectionIsEstablished = true;
        var recentProjectsCacheKey = $"{id}-{RecentRequestEntityType.Project}";

        try
        {
            var cachedResponse = await _cache.GetStringAsync(recentProjectsCacheKey);
            if (cachedResponse is not null)
            {
                return Ok(JsonSerializer.Deserialize<IEnumerable<ProjectResponse>>(cachedResponse));
            }
        }
        catch (RedisConnectionException)
        {
            cacheConnectionIsEstablished = false;
        }

        var query = new GetRecentProjectsQuery { UserId = id };
        var projects = await _mediator.Send(query);

        if (cacheConnectionIsEstablished)
        {
            await _cache.SetStringAsync(
                recentProjectsCacheKey,
                JsonSerializer.Serialize(projects),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                });
        }

        return Ok(projects);
    }

    [HttpGet("teams/{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRecentTeamsAsync([FromRoute] Guid id)
    {
        var cacheConnectionIsEstablished = true;
        var recentTeamsCacheKey = $"{id}-{RecentRequestEntityType.Team}";

        try
        {
            var cachedResponse = await _cache.GetStringAsync(recentTeamsCacheKey);
            if (cachedResponse is not null)
            {
                return Ok(JsonSerializer.Deserialize<IEnumerable<TeamResponse>>(cachedResponse));
            }
        }
        catch (RedisConnectionException)
        {
            cacheConnectionIsEstablished = false;
        }

        var query = new GetRecentTeamsQuery { UserId = id };
        var teams = await _mediator.Send(query);

        if (cacheConnectionIsEstablished)
        {
            await _cache.SetStringAsync(
                $"{id}-{RecentRequestEntityType.Team}",
                JsonSerializer.Serialize(teams));
        }

        return Ok(teams);
    }

    [HttpGet("tickets/{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRecentTicketsAsync([FromRoute] Guid id)
    {
        var cacheConnectionIsEstablished = true;
        var recentTicketsCacheKey = $"{id}-{RecentRequestEntityType.Ticket}";

        try
        {
            var cachedResponse = await _cache.GetStringAsync(recentTicketsCacheKey);
            if (cachedResponse is not null)
            {
                return Ok(JsonSerializer.Deserialize<IEnumerable<TicketResponse>>(cachedResponse));
            }
        }
        catch (RedisConnectionException)
        {
            cacheConnectionIsEstablished = false;
        }

        var query = new GetRecentTicketsQuery { UserId = id };
        var tickets = await _mediator.Send(query);

        if (cacheConnectionIsEstablished)
        {
            await _cache.SetStringAsync(
                recentTicketsCacheKey,
                JsonSerializer.Serialize(tickets));
        }

        return Ok(tickets);
    }
}
