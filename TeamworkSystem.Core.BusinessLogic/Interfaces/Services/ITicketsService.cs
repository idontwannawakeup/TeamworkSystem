using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Core.BusinessLogic.Interfaces.Services;

public interface ITicketsService
{
    Task<IEnumerable<TicketResponse>> GetAsync();
    Task<PagedList<TicketResponse>> GetAsync(TicketsParameters parameters);
    Task<TicketResponse> GetByIdAsync(int id);
    Task InsertAsync(TicketRequest request);
    Task UpdateAsync(TicketRequest request);
    Task ExtendDeadlineAsync(TicketWithExtendedDeadlineRequest request);
    Task DeleteAsync(int id);
}
