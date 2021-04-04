using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface ITicketsRepository : IRepository<Ticket>
    {
        Task<Ticket> GetCompleteTicketAsync(int id);

        Task<IEnumerable<Ticket>> GetByProjectIdAndStatus(int projectId, string status);
    }
}
