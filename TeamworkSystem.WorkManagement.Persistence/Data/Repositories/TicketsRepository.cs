using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Shared.Exceptions;
using TeamworkSystem.Shared.Extensions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Interfaces.Repositories;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Persistence.Data.Repositories;

public class TicketsRepository : GenericRepository<Ticket>, ITicketsRepository
{
    private readonly IFilterFactory<Ticket> _filter;

    public TicketsRepository(WorkManagementDbContext databaseContext, IFilterFactory<Ticket> filter)
        : base(databaseContext) => _filter = filter;

    public override async Task<Ticket> GetCompleteEntityAsync(Guid id)
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
