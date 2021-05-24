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
    public class TicketsRepository : GenericRepository<Ticket>, ITicketsRepository
    {
        public override async Task<Ticket> GetCompleteEntityAsync(int id)
        {
            var ticket = await table.Include(ticket => ticket.Executor)
                                    .Include(ticket => ticket.Project)
                                    .ThenInclude(project => project.Team)
                                    .SingleOrDefaultAsync(ticket => ticket.Id == id);

            return ticket ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<PagedList<Ticket>> GetAsync(TicketsParameters parameters)
        {
            IQueryable<Ticket> source = table.Include(ticket => ticket.Executor);

            SearchByProjectId(ref source, parameters.ProjectId);
            SearchByExecutorId(ref source, parameters.ExecutorId);
            SearchByTitle(ref source, parameters.Title);

            return await PagedList<Ticket>.ToPagedListAsync(
                source,
                parameters.PageNumber,
                parameters.PageSize);
        }

        private static void SearchByProjectId(ref IQueryable<Ticket> source, int? projectId)
        {
            if (projectId is null || projectId == 0)
            {
                return;
            }

            source = source.Where(ticket => ticket.ProjectId == projectId);
        }

        private static void SearchByExecutorId(ref IQueryable<Ticket> source, string executorId)
        {
            if (string.IsNullOrWhiteSpace(executorId))
            {
                return;
            }

            source = source.Where(ticket => ticket.ExecutorId == executorId);
        }

        private static void SearchByTitle(ref IQueryable<Ticket> source, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return;
            }

            source = source.Where(ticket => ticket.Title.Contains(title));
        }

        public TicketsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
