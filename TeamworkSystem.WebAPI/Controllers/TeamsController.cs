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
    public class TeamsController : ControllerBase
    {
        private readonly IRepository<Team> repository;

        private readonly ILogger<TeamsController> logger;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> Get()
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
        public async Task<ActionResult<Team>> Get([FromRoute] int id)
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
        public async Task<ActionResult> Post([FromBody] Team team)
        {
            try
            {
                await this.repository.InsertAsync(team);
                return this.Ok();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Team team)
        {
            try
            {
                await this.repository.UpdateAsync(id, team);
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

        public TeamsController(
            IRepository<Team> repository,
            ILogger<TeamsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
    }
}
