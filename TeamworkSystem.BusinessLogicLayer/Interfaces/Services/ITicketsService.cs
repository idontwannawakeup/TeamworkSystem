﻿using System.Collections.Generic;
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

        Task ExtendDeadlineAsync(TicketWithExtendedDeadlineRequest request);

        Task DeleteAsync(int id);
    }
}
