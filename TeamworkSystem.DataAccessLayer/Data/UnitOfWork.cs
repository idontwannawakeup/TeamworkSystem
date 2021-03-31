using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly TeamworkSystemContext databaseContext;

        public UserManager<User> UserManager { get; }

        public SignInManager<User> SignInManager { get; }

        public IProjectsRepository ProjectsRepository { get; }

        public IRatingsRepository RatingsRepository { get; }

        public ITeamsRepository TeamsRepository { get; }

        public ITicketsRepository TicketsRepository { get; }

        public async Task SaveChangesAsync()
        {
            await this.databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(TeamworkSystemContext databaseContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IProjectsRepository projectsRepository,
            IRatingsRepository ratingsRepository,
            ITeamsRepository teamsRepository,
            ITicketsRepository ticketsRepository)
        {
            this.databaseContext = databaseContext;
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            this.ProjectsRepository = projectsRepository;
            this.RatingsRepository = ratingsRepository;
            this.TeamsRepository = teamsRepository;
            this.TicketsRepository = ticketsRepository;
        }
    }
}
