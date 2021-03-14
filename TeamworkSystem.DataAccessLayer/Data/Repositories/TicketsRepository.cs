using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class TicketsRepository
        : GenericRepository<Ticket>, ITicketsRepository
    {
        public TicketsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
