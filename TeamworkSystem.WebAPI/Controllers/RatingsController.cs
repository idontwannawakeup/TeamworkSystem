using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Models;

namespace TeamworkSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IRepository<Rating, (int, int)> repository;

        private readonly ILogger<RatingsController> logger;

        // TODO make api methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> Get()
        {
            try
            {
                return this.Ok(await this.repository.GetAsync());
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
            }
        }

        [HttpGet("{from}/{to}")]
        public async Task<ActionResult<Rating>> Get([FromRoute] int @from, [FromRoute] int to)
        {
            try
            {
                return this.Ok(await this.repository.GetByKeyAsync((@from, to)));
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Rating rating)
        {
            try
            {
                await this.repository.InsertAsync(rating);
                return this.Ok();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest();
            }
        }

        [HttpPut("{from}/{to}")]
        public async Task<ActionResult> Put(
            [FromRoute] int @from,
            [FromRoute] int to,
            [FromBody] Rating rating)
        {
            try
            {
                await this.repository.UpdateAsync((@from, to), rating);
                return this.Ok();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
            }
        }

        [HttpDelete("{from}/{to}")]
        public async Task<ActionResult> Delete([FromRoute] int @from, [FromRoute] int to)
        {
            try
            {
                await this.repository.DeleteAsync((@from, to));
                return this.Ok();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
            }
        }

        public RatingsController(
            IRepository<Rating, (int, int)> repository,
            ILogger<RatingsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
    }
}