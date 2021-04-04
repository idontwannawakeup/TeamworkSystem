using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Exceptions;

namespace TeamworkSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService teamsService;

        private readonly ILogger<TeamsController> logger;

        [HttpGet("profiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TeamProfileResponse>>> GetProfilesAsync()
        {
            try
            {
                return this.Ok(await this.teamsService.GetProfilesAsync());
            }
            catch (Exception e)
            {
                string message = e.Message;
                this.logger.LogError(message);
                return this.BadRequest(message);
            }
        }

        [HttpGet("profiles/user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TeamProfileResponse>>> GetProfilesOfUserTeamsAsync(
            [FromRoute] string userId)
        {
            try
            {
                return this.Ok(await this.teamsService.GetProfilesOfUserTeamsAsync(userId));
            }
            catch (EntityNotFoundException e)
            {
                string message = e.Message;
                this.logger.LogError(message);
                return this.NotFound(message);
            }
            catch (Exception e)
            {
                string message = e.Message;
                this.logger.LogError(message);
                return this.BadRequest(message);
            }
        }

        [HttpGet("profiles/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeamProfileResponse>> GetProfileByIdAsync([FromRoute] int id)
        {
            try
            {
                return this.Ok(await this.teamsService.GetProfileByIdAsync(id));
            }
            catch (EntityNotFoundException e)
            {
                string message = e.Message;
                this.logger.LogError(message);
                return this.NotFound(message);
            }
            catch (Exception e)
            {
                string message = e.Message;
                this.logger.LogError(message);
                return this.BadRequest(message);
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
                string message = e.Message;
                this.logger.LogError(message);
                return this.BadRequest(message);
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
                string message = e.Message;
                this.logger.LogError(message);
                return this.NotFound(message);
            }
            catch (Exception e)
            {
                string message = e.Message;
                this.logger.LogError(message);
                return this.BadRequest(message);
            }
        }

        public TeamsController(
            ITeamsService teamsService,
            ILogger<TeamsController> logger)
        {
            this.teamsService = teamsService;
            this.logger = logger;
        }
    }
}
