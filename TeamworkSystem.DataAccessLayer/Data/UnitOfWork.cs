using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Data.Repositories;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly TeamworkSystemContext databaseContext;

        public IUsersRepository UsersRepository { get; }

        public ITeamsRepository TeamsRepository { get; }

        public IProjectsRepository ProjectsRepository { get; }

        public ITicketsRepository TicketsRepository { get; }

        public IRatingsRepository RatingsRepository { get; }

        public async Task SaveChangesAsync()
        {
            await this.databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(TeamworkSystemContext databaseContext)
        {
            this.databaseContext = databaseContext;
            this.UsersRepository = new UsersRepository(this.databaseContext);
            this.TeamsRepository = new TeamsRepository(this.databaseContext);
            this.ProjectsRepository = new ProjectsRepository(this.databaseContext);
            this.TicketsRepository = new TicketsRepository(this.databaseContext);
            this.RatingsRepository = new RatingsRepository(this.databaseContext);
        }
    }
}
