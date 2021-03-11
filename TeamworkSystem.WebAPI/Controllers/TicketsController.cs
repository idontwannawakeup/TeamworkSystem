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
    public class TicketsController : ControllerBase
    {
        private readonly IRepository<Ticket> repository;

        private readonly ILogger<TicketsController> logger;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> Get()
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
        public async Task<ActionResult<Ticket>> Get([FromRoute] int id)
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
        public async Task<ActionResult> Post([FromBody] Ticket ticket)
        {
            try
            {
                await this.repository.InsertAsync(ticket);
                return this.Ok();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Ticket ticket)
        {
            try
            {
                await this.repository.UpdateAsync(id, ticket);
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

        public TicketsController(
            IRepository<Ticket> repository,
            ILogger<TicketsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
    }
}
