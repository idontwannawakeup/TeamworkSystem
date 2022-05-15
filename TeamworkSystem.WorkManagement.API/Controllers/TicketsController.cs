using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Core.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketsService _ticketsService;

    public TicketsController(ITicketsService ticketsService) =>
        _ticketsService = ticketsService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedList<TicketResponse>>> GetAsync(
        [FromQuery] TicketsParameters parameters)
    {
        var tickets = await _ticketsService.GetAsync(parameters);
        Response.Headers.Add("X-Pagination", tickets.SerializeMetadata());
        return Ok(tickets);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TicketResponse>> GetByIdAsync([FromRoute] Guid id) =>
        Ok(await _ticketsService.GetByIdAsync(id));

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertAsync([FromBody] TicketRequest request)
    {
        await _ticketsService.InsertAsync(request);
        return Ok();
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateAsync([FromBody] TicketRequest request)
    {
        await _ticketsService.UpdateAsync(request);
        return Ok();
    }

    [HttpPut("deadline")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> ExtendDeadlineAsync(
        [FromBody] TicketWithExtendedDeadlineRequest request)
    {
        await _ticketsService.ExtendDeadlineAsync(request);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _ticketsService.DeleteAsync(id);
        return Ok();
    }
}
