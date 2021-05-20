using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface ITicketsService
    {
        Task<IEnumerable<TicketViewModel>> GetTicketsForUserAsync(string userId);

        Task<TicketViewModel> GetByIdAsync(int id);

        Task<IEnumerable<TicketViewModel>> GetByProjectIdAsync(int projectId);

        Task DeleteAsync(int id);
    }
}
