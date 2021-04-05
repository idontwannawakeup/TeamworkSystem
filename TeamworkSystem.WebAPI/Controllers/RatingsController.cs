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
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsService ratingsService;

        [HttpGet("profiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RatingProfileResponse>>> GetAllProfilesAsync()
        {
            try
            {
                return this.Ok(await this.ratingsService.GetAllProfilesAsync());
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
        public async Task<ActionResult<IEnumerable<RatingProfileResponse>>> GetProfileByIdAsync([FromRoute] int id)
        {
            try
            {
                return this.Ok(await this.ratingsService.GetProfileByIdAsync(id));
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
        public async Task<ActionResult> InsertAsync([FromBody] RatingRequest request)
        {
            try
            {
                await this.ratingsService.InsertAsync(request);
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
                await this.ratingsService.DeleteAsync(id);
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

        public RatingsController(IRatingsService ratingsService)
        {
            this.ratingsService = ratingsService;
        }
    }
}
