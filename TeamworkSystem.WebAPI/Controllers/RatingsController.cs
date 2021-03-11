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
        private readonly IRepository<Rating> repository;

        private readonly ILogger<RatingsController> logger;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> Get([FromRoute] int id)
        {
            try
            {
                return this.Ok(await this.repository.GetByIdAsync(id));
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

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id,
            [FromBody] Rating rating)
        {
            try
            {
                await this.repository.UpdateAsync(id, rating);
                return this.Ok();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await this.repository.DeleteAsync(id);
                return this.Ok();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
            }
        }

        public RatingsController(
            IRepository<Rating> repository,
            ILogger<RatingsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
    }
}
