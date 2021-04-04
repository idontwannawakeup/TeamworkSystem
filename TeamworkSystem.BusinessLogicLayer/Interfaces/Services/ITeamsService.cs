using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface ITeamsService
    {
        Task<IEnumerable<TeamProfileResponse>> GetProfilesAsync();

        Task<IEnumerable<TeamProfileResponse>> GetProfilesOfUserTeamsAsync(string userId);

        Task<TeamProfileResponse> GetProfileByIdAsync(int id);

        Task InsertAsync(TeamRequest request);

        Task DeleteAsync(int id);
    }
}
