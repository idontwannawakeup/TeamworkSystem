using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Data.Repositories;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly TeamworkSystemContext databaseContext;

        public IUsersRepository UsersRepository
            => new UsersRepository(this.databaseContext);

        public ITeamsRepository TeamsRepository
            => new TeamsRepository(this.databaseContext);

        public IProjectsRepository ProjectsRepository
            => new ProjectsRepository(this.databaseContext);

        public ITicketsRepository TicketsRepository
            => new TicketsRepository(this.databaseContext);

        public IRatingsRepository RatingsRepository
            => new RatingsRepository(this.databaseContext);

        public async Task SaveChangesAsync()
        {
            await this.databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(TeamworkSystemContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}
