using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces;

public interface ITicketsService
{
    Task<IEnumerable<TicketViewModel>> GetAsync(TicketsParameters parameters);

    Task<(IEnumerable<TicketViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
        TicketsParameters parameters);

    Task<IEnumerable<TicketViewModel>> GetTicketsForUserAsync(Guid userId);

    Task<TicketViewModel> GetByIdAsync(Guid id);

    Task<IEnumerable<TicketViewModel>> GetByProjectIdAsync(Guid projectId);

    Task CreateAsync(TicketViewModel viewModel);

    Task UpdateAsync(TicketViewModel viewModel);

    Task DeleteAsync(Guid id);
}
