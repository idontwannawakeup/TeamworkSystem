﻿using System.Text;
using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using TeamworkSystem.Content.Application.Common.Responses;
using TeamworkSystem.Content.Application.Recent.Queries.GetRecentProjects;
using TeamworkSystem.Content.Application.Recent.Queries.GetRecentTeams;
using TeamworkSystem.Content.Application.Recent.Queries.GetRecentTickets;

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
        var cachedResponse = await _cache.GetStringAsync($"{id}-{0}");
        if (cachedResponse is not null)
        {
            return Ok(JsonSerializer.Deserialize<IEnumerable<ProjectResponse>>(cachedResponse));
        }

        var query = new GetRecentProjectsQuery { UserId = id };
        var projects = await _mediator.Send(query);
        await _cache.SetStringAsync(
            $"{id}-{0}",
            JsonSerializer.Serialize(projects));

        return Ok(projects);
    }

    [HttpGet("teams/{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRecentTeamsAsync([FromRoute] Guid id)
    {
        var query = new GetRecentTeamsQuery { UserId = id };
        var teams = await _mediator.Send(query);
        return Ok(teams);
    }

    [HttpGet("tickets/{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRecentTicketsAsync([FromRoute] Guid id)
    {
        var query = new GetRecentTicketsQuery { UserId = id };
        var tickets = await _mediator.Send(query);
        return Ok(tickets);
    }
}
