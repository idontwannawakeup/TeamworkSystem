using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IRatingsService
    {
        Task<IEnumerable<RatingProfileResponse>> GetAllProfilesAsync();

        Task<RatingProfileResponse> GetProfileByIdAsync(int id);

        Task InsertAsync(RatingRequest request);

        Task DeleteAsync(int id);
    }
}
