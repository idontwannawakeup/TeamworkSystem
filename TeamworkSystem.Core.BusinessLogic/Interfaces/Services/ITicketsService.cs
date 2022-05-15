using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.Core.BusinessLogic.Interfaces.Services;

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
