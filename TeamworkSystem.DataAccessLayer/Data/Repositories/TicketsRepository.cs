using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories;

public class TicketsRepository : GenericRepository<Ticket>, ITicketsRepository
{
    public TicketsRepository(TeamworkSystemContext databaseContext) : base(databaseContext)
    {
    }

    public override async Task<Ticket> GetCompleteEntityAsync(int id)
    {
        var ticket = await Table.Include(ticket => ticket.Executor)
                                .Include(ticket => ticket.Project)
                                .ThenInclude(project => project.Team)
                                .SingleOrDefaultAsync(ticket => ticket.Id == id);

        return ticket ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }

    public async Task<PagedList<Ticket>> GetAsync(TicketsParameters parameters)
    {
        IQueryable<Ticket> source = Table.Include(ticket => ticket.Executor)
                                         .Include(ticket => ticket.Project)
                                         .ThenInclude(project => project.Team);

        SearchByProjectId(ref source, parameters.ProjectId);
        SearchByExecutorId(ref source, parameters.ExecutorId);
        SearchByTitle(ref source, parameters.Title);
        SearchByStatus(ref source, parameters.Status);

        return await PagedList<Ticket>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    private static void SearchByProjectId(ref IQueryable<Ticket> source, int? projectId)
    {
        if (projectId is null or 0)
        {
            return;
        }

        source = source.Where(ticket => ticket.ProjectId == projectId);
    }

    private static void SearchByExecutorId(ref IQueryable<Ticket> source, string? executorId)
    {
        if (string.IsNullOrWhiteSpace(executorId))
        {
            return;
        }

        source = source.Where(ticket => ticket.ExecutorId == executorId);
    }

    private static void SearchByTitle(ref IQueryable<Ticket> source, string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return;
        }

        source = source.Where(ticket => ticket.Title.Contains(title));
    }

    private static void SearchByStatus(ref IQueryable<Ticket> source, string? status)
    {
        if (string.IsNullOrWhiteSpace(status))
        {
            return;
        }

        source = source.Where(ticket => ticket.Status == status);
    }
}
