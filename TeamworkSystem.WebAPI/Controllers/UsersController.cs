using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Models;

namespace TeamworkSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> repository;

        private readonly ILogger<UsersController> logger;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAsync()
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
        public async Task<ActionResult<User>> GetAsync([FromRoute] int id)
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
        public async Task<ActionResult> PostAsync([FromBody] User user)
        {
            try
            {
                await this.repository.InsertAsync(user);
                return this.Ok();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] User user)
        {
            try
            {
                await this.repository.UpdateAsync(id, user);
                return this.Ok();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
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

        public UsersController(
            IRepository<User> repository,
            ILogger<UsersController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
    }
}
