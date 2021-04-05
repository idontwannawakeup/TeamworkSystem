using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IProjectsService
    {
        Task<IEnumerable<ProjectProfileResponse>> GetAllProfilesAsync();

        Task<IEnumerable<ProjectProfileResponse>> GetProfilesOfTeamProjectsAsync(int teamId);

        Task<ProjectProfileResponse> GetProfileByIdAsync(int id);

        Task InsertAsync(ProjectRequest request);

        Task DeleteAsync(int id);
    }
}
