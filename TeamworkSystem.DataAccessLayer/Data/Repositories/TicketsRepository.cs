using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
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
                .SingleOrDefaultAsync(ticket => ticket.Id == id)
                    ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<IEnumerable<Ticket>> GetByProjectIdAndStatus(int projectId, string status)
        {
            return await this.table
                .Where(ticket => ticket.ProjectId == projectId && ticket.Status == status)
                .ToListAsync();
        }

        public TicketsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
