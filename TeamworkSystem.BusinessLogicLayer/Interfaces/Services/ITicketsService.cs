using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface ITicketsService
    {
        Task<IEnumerable<TicketProfileResponse>> GetProfilesAsync();

        Task<IEnumerable<TicketProfileResponse>> GetProfilesAsync(TicketsByProjectAndStatusRequest request);

        Task<TicketProfileResponse> GetProfileByIdAsync(int id);

        Task ExtendDeadline(TicketWithExtendedDeadlineRequest request);

        Task Delete(int id);
    }
}
