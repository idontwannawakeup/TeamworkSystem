using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface ITicketsService
    {
        Task<IEnumerable<TicketViewModel>> GetAsync(TicketsParameters parameters);

        Task<(IEnumerable<TicketViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            TicketsParameters parameters);

        Task<IEnumerable<TicketViewModel>> GetTicketsForUserAsync(string userId);

        Task<TicketViewModel> GetByIdAsync(int id);

        Task<IEnumerable<TicketViewModel>> GetByProjectIdAsync(int projectId);

        Task CreateAsync(TicketViewModel viewModel);

        Task UpdateAsync(TicketViewModel viewModel);

        Task DeleteAsync(int id);
    }
}
