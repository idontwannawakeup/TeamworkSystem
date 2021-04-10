using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface ITeamsService
    {
        Task<IEnumerable<TeamProfileResponse>> GetAllProfilesAsync();

        Task<PagedResponse<TeamProfileResponse>> GetProfilesPageAsync(PaginationParameters parameters);

        Task<IEnumerable<TeamProfileResponse>> GetProfilesOfUserTeamsAsync(string userId);

        Task<PagedResponse<TeamProfileResponse>> GetProfilesPageOfUserTeamsAsync(
            string userId,
            PaginationParameters parameters);

        Task<TeamProfileResponse> GetProfileByIdAsync(int id);

        Task InsertAsync(TeamRequest request);

        Task DeleteAsync(int id);
    }
}
