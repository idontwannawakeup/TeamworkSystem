using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class TicketsRepository
        : GenericRepository<Ticket>, ITicketsRepository
    {
        public async Task<PagedList<Ticket>> GetAsync(
            TicketsParameters parameters)
        {
            IQueryable<Ticket> source = table;
            return await PagedList<Ticket>.ToPagedListAsync(
                source,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public override async Task<Ticket> GetCompleteEntityAsync(int id)
        {
            return await table
                .Include(ticket => ticket.Project)
                .Include(ticket => ticket.Executor)
                .SingleOrDefaultAsync(ticket => ticket.Id == id)
                    ?? throw new EntityNotFoundException(
                        GetEntityNotFoundErrorMessage(id));
        }

        public TicketsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
