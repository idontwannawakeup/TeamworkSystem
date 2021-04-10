﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService teamsService;

        [HttpGet("profiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TeamProfileResponse>>> GetAllProfilesAsync()
        {
            try
            {
                return this.Ok(await this.teamsService.GetAllProfilesAsync());
            }
            catch (Exception e)
            {
                return this.BadRequest(new { e.Message });
            }
        }

        [HttpGet("profiles/page")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedResponse<TeamProfileResponse>>> GetProfilesPage([FromQuery] PaginationParameters parameters)
        {
            try
            {
                return this.Ok(await this.teamsService.GetProfilesPageAsync(parameters));
            }
            catch (Exception e)
            {
                return this.BadRequest(new { e.Message });
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
                return this.NotFound(new { e.Message });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { e.Message });
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
                return this.NotFound(new { e.Message });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { e.Message });
            }
        }

        [HttpGet("profiles/page/user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedResponse<TeamProfileResponse>>> GetProfilesPageOfUserTeamsAsync(
            [FromRoute] string userId,
            [FromQuery] PaginationParameters parameters)
        {
            try
            {
                return this.Ok(await this.teamsService.GetProfilesPageOfUserTeamsAsync(userId, parameters));
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
