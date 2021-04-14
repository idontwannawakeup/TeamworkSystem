using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;
using TeamworkSystem.WebAPI.Extensions;

namespace TeamworkSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService teamsService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<TeamResponse>>> GetAsync(
            [FromQuery] TeamsParameters parameters)
        {
            try
            {
                PagedList<TeamResponse> profiles =
                    await this.teamsService.GetAsync(parameters);

                this.Response.Headers.Add(
                    "X-Pagination",
                    profiles.SerializeMetadata());

                return this.Ok(profiles);
            }
            catch (Exception e)
            {
                return this.BadRequest(new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeamResponse>> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                return this.Ok(await this.teamsService.GetByIdAsync(id));
            }
            catch (EntityNotFoundException e)
            {
                return this.NotFound(new { e.Message });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { e.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> InsertAsync([FromBody] TeamRequest request)
        {
            try
            {
                await this.teamsService.InsertAsync(request);
                return this.Ok();
            }
            catch (Exception e)
            {
                return this.BadRequest(new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                await this.teamsService.DeleteAsync(id);
                return this.Ok();
            }
            catch (EntityNotFoundException e)
            {
                return this.NotFound(new { e.Message });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { e.Message });
            }
        }

        public TeamsController(ITeamsService teamsService)
        {
            this.teamsService = teamsService;
        }
    }
}
