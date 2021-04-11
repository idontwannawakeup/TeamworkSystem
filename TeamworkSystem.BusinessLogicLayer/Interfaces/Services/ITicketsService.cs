using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface ITicketsService
    {
        Task<IEnumerable<TicketResponse>> GetAsync();

        Task<IEnumerable<TicketResponse>> GetAsync(TicketsByProjectAndStatusRequest request);

        Task<TicketResponse> GetProfileByIdAsync(int id);

        Task InsertAsync(TicketRequest request);

        Task ExtendDeadlineAsync(TicketWithExtendedDeadlineRequest request);

        Task DeleteAsync(int id);
    }
}
