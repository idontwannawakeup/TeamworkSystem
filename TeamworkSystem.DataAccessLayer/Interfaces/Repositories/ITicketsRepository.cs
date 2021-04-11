using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface ITicketsRepository : IRepository<Ticket>
    {
        Task<PagedList<Ticket>> GetAsync(TicketsParameters parameters);
    }
}
