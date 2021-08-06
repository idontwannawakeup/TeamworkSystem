using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly TeamworkSystemContext DatabaseContext;

        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }
        public IProjectsRepository ProjectsRepository { get; }
        public IRatingsRepository RatingsRepository { get; }
        public ITeamsRepository TeamsRepository { get; }
        public ITicketsRepository TicketsRepository { get; }

        public async Task SaveChangesAsync() => await DatabaseContext.SaveChangesAsync();

        public UnitOfWork(TeamworkSystemContext databaseContext,
                          UserManager<User> userManager,
                          SignInManager<User> signInManager,
                          IProjectsRepository projectsRepository,
                          IRatingsRepository ratingsRepository,
                          ITeamsRepository teamsRepository,
                          ITicketsRepository ticketsRepository)
        {
            DatabaseContext = databaseContext;
            UserManager = userManager;
            SignInManager = signInManager;
            ProjectsRepository = projectsRepository;
            RatingsRepository = ratingsRepository;
            TeamsRepository = teamsRepository;
            TicketsRepository = ticketsRepository;
        }
    }
}
