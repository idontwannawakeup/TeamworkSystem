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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedList<UserResponse>>> GetAsync(
            [FromQuery] UsersParameters parameters)
        {
            try
            {
                PagedList<UserResponse> users =
                    await this.usersService.GetAsync(parameters);

                this.Response.Headers.Add(
                    "X-Pagination",
                    users.SerializeMetadata());

                return this.Ok(users);
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
        public async Task<ActionResult<UserResponse>> GetByIdAsync([FromRoute] string id)
        {
            try
            {
                return this.Ok(await this.usersService.GetByIdAsync(id));
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

        [HttpGet("friends/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<UserResponse>>> GetFriends(
            [FromRoute] string id,
            [FromQuery] UsersParameters parameters)
        {
            try
            {
                PagedList<UserResponse> friends =
                    await this.usersService.GetFriendsAsync(id, parameters);

                this.Response.Headers.Add(
                    "X-Pagination",
                    friends.SerializeMetadata());

                return this.Ok(friends);
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

        [HttpPost("signUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SignUpAsync([FromBody] UserSignUpRequest user)
        {
            try
            {
                await this.usersService.SignUpAsync(user);
                return this.Ok();
            }
            catch (ArgumentException e)
            {
                return this.BadRequest(new { e.Message });
            }
        }

        [HttpPost("friends")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddFriendAsync([FromBody] FriendsRequest request)
        {
            try
            {
                await this.usersService.AddFriendAsync(request);
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

        [HttpDelete("friends")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteFriendAsync([FromBody] FriendsRequest request)
        {
            try
            {
                await this.usersService.DeleteFriendAsync(request);
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync([FromRoute] string id)
        {
            try
            {
                await this.usersService.DeleteAsync(id);
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
            this.usersService = usersService;
        }
    }
}
