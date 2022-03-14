using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.BusinessLogic.DTO.Requests;
using TeamworkSystem.Social.BusinessLogic.DTO.Responses;
using TeamworkSystem.Social.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RatingsController : ControllerBase
{
    private readonly IRatingsService _ratingsService;

    public RatingsController(IRatingsService ratingsService) => _ratingsService = ratingsService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedList<RatingResponse>>> GetAsync(
        [FromQuery] RatingsParameters parameters)
    {
        var ratings = await _ratingsService.GetAsync(parameters);
        Response.Headers.Add("X-Pagination", ratings.SerializeMetadata());
        return Ok(ratings);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<RatingResponse>>> GetByIdAsync([FromRoute] Guid id) =>
        Ok(await _ratingsService.GetByIdAsync(id));

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertAsync([FromBody] RatingRequest request)
    {
        try
        {
            await _ratingsService.InsertAsync(request);
            return Ok();
        }
        catch (DbUpdateException)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { Message = "Rating from you to this user already exists." });
        }
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateAsync([FromBody] RatingRequest request)
    {
        await _ratingsService.UpdateAsync(request);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _ratingsService.DeleteAsync(id);
        return Ok();
    }
}
