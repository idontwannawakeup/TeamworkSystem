using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<UserProfileResponse>>> GetAsync()
        {
            try
            {
                return this.Ok(await this.usersServices.GetAllProfilesAsync());
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
            }
        }

        [HttpGet("{id}")]
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
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] string id)
        {
            try
            {
                await this.usersServices.DeleteAsync(id);
                return this.Ok();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
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
