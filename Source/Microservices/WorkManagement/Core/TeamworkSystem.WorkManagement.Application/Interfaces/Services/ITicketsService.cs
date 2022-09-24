using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Models.Requests;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Interfaces.Services;

public interface ITicketsService
{
    Task<IEnumerable<TicketResponse>> GetAsync();
    Task<PagedList<TicketResponse>> GetAsync(TicketsParameters parameters);
    Task<TicketResponse> GetByIdAsync(Guid id);
    Task InsertAsync(TicketRequest request);
    Task UpdateAsync(TicketRequest request);
    Task ExtendDeadlineAsync(TicketWithExtendedDeadlineRequest request);
    Task DeleteAsync(Guid id);
}
