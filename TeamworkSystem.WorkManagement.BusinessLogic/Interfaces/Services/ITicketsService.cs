using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Requests;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Responses;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.BusinessLogic.Interfaces.Services;

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
