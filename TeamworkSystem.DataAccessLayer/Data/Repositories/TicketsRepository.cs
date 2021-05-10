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
            SearchByProjectId(ref source, parameters.ProjectId);
            SearchByExecutorId(ref source, parameters.ExecutorId);
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

        private static void SearchByProjectId(
            ref IQueryable<Ticket> source,
            int? projectId)
        {
            if (projectId is null || projectId == 0)
            {
                return;
            }

            source = source.Where(ticket => ticket.ProjectId == projectId);
        }

        private static void SearchByExecutorId(
            ref IQueryable<Ticket> source,
            string executorId)
        {
            if (string.IsNullOrWhiteSpace(executorId))
            {
                return;
            }

            source = source.Where(ticket => ticket.ExecutorId == executorId);
        }

        public TicketsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
