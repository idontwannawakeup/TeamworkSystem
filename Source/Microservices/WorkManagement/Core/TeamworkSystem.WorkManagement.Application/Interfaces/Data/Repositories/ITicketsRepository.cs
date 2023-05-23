using TeamworkSystem.Shared.Interfaces;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Interfaces.Data.Repositories;

public interface ITicketsRepository : IRepository<Ticket>
{
    Task<PagedList<Ticket>> GetAsync(TicketsParameters parameters);
    Task<IEnumerable<Ticket>> GetAsync(IEnumerable<Guid> ids);
}
