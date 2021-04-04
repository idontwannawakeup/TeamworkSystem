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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersServices;

        private readonly ILogger<UsersController> logger;

        [HttpPost("signUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SignUpAsync([FromBody] UserSignUpRequest user)
        {
            try
            {
                await this.usersServices.SignUpAsync(user);
                return this.Ok();
            }
            catch (ArgumentException e)
            {
                string message = e.Message;
                this.logger.LogError(message);
                return this.BadRequest(message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserProfileResponse>>> GetAsync()
        {
            try
            {
                return this.Ok(await this.usersServices.GetAllProfilesAsync());
            }
            catch (Exception e)
            {
                string message = e.Message;
                this.logger.LogError(message);
                return this.NotFound(message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserProfileResponse>> GetAsync([FromRoute] string id)
        {
            try
            {
                return this.Ok(await this.usersServices.GetProfileByIdAsync(id));
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync([FromRoute] string id)
        {
            try
            {
                await this.usersServices.DeleteAsync(id);
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

        public UsersController(
            IUsersService usersService,
            ILogger<UsersController> logger)
        {
            this.usersServices = usersService;
            this.logger = logger;
        }
    }
}
