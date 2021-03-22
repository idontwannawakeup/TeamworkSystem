using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersServices;

        private readonly ILogger<UsersController> logger;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAsync()
        {
            try
            {
                return this.Ok(await this.usersServices.GetAllAsync());
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync([FromRoute] string id)
        {
            try
            {
                return this.Ok(await this.usersServices.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.NotFound();
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

        public UsersController(IUsersService usersService,
            ILogger<UsersController> logger)
        {
            this.usersServices = usersService;
            this.logger = logger;
        }
    }
}
