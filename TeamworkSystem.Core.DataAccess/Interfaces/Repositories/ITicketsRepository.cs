using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Core.DataAccess.Interfaces.Repositories;

public interface ITicketsRepository : IRepository<Ticket>
{
    Task<PagedList<Ticket>> GetAsync(TicketsParameters parameters);
}
