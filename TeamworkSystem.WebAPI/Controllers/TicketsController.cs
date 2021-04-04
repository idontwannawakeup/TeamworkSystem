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
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService ticketsService;

        private readonly ILogger<TicketsController> logger;

        [HttpGet("profiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TicketProfileResponse>>> GetProfilesAsync()
        {
            try
            {
                return this.Ok(await this.ticketsService.GetProfilesAsync());
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
        public async Task<ActionResult<TicketProfileResponse>> GetProfileAsync([FromRoute] int id)
        {
            try
            {
                return this.Ok(await this.ticketsService.GetProfileByIdAsync(id));
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

        [HttpGet("profiles/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TicketProfileResponse>>> GetProfilesAsync(
            [FromBody] TicketsByProjectAndStatusRequest request)
        {
            try
            {
                return this.Ok(await this.ticketsService.GetProfilesAsync(request));
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
        public async Task<ActionResult> InsertAsync(TicketRequest request)
        {
            try
            {
                await this.ticketsService.InsertAsync(request);
                return this.Ok();
            }
            catch (Exception e)
            {
                string message = e.Message;
                this.logger.LogError(message);
                return this.BadRequest(message);
            }
        }

        [HttpPut("deadline")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ExtendDeadlineAsync(TicketWithExtendedDeadlineRequest request)
        {
            try
            {
                await this.ticketsService.ExtendDeadlineAsync(request);
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                await this.ticketsService.DeleteAsync(id);
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

        public TicketsController(
            ITicketsService ticketsService,
            ILogger<TicketsController> logger)
        {
            this.ticketsService = ticketsService;
            this.logger = logger;
        }
    }
}
