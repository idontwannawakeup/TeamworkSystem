using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Extensions;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories;

public class TicketsRepository : GenericRepository<Ticket>, ITicketsRepository
{
    private readonly IFilterFactory<Ticket> _filter;

    public TicketsRepository(TeamworkSystemContext databaseContext, IFilterFactory<Ticket> filter)
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
