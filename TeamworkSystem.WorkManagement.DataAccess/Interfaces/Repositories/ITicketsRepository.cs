using TeamworkSystem.Shared.Interfaces;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.DataAccess.Entities;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.DataAccess.Interfaces.Repositories;

public interface ITicketsRepository : IRepository<Ticket>
{
    Task<PagedList<Ticket>> GetAsync(TicketsParameters parameters);
}
