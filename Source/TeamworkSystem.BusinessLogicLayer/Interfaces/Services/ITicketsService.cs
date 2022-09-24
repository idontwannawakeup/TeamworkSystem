using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services;

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
