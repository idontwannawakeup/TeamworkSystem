using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                return this.BadRequest(new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserProfileResponse>>> GetAllProfilesAsync()
        {
            try
            {
                return this.Ok(await this.usersServices.GetAllProfilesAsync());
            }
            catch (Exception e)
            {
                return this.NotFound(new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserProfileResponse>> GetProfileByIdAsync([FromRoute] string id)
        {
            try
            {
                return this.Ok(await this.usersServices.GetProfileByIdAsync(id));
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
                return this.NotFound(new { e.Message });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { e.Message });
            }
        }

        public UsersController(IUsersService usersService)
        {
            this.usersServices = usersService;
        }
    }
}
