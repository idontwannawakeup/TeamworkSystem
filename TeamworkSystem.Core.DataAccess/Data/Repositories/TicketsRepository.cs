using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Interfaces.Repositories;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Exceptions;
using TeamworkSystem.Shared.Extensions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Core.DataAccess.Data.Repositories;

public class TicketsRepository : GenericRepository<Ticket>, ITicketsRepository
{
    private readonly IFilterFactory<Ticket> _filter;

    public TicketsRepository(TeamworkSystemCoreDbContext databaseContext, IFilterFactory<Ticket> filter)
        : base(databaseContext) => _filter = filter;

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
                                         .ThenInclude(project => project.Team)
                                         .FilterWith(_filter.Get(parameters));

        return await PagedList<Ticket>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }
}
