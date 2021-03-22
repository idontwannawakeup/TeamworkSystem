using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class TicketsRepository
        : GenericRepository<Ticket>, ITicketsRepository
    {
        public async Task<Ticket> GetCompleteTicketAsync(int id)
        {
            return await this.table
                .Include(ticket => ticket.Project)
                .Include(ticket => ticket.Executor)
                .SingleOrDefaultAsync(ticket => ticket.Id == id);
        }

        public TicketsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
