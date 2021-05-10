using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IRatingsService
    {
        Task<IEnumerable<RatingResponse>> GetAsync();

        Task<PagedList<RatingResponse>> GetAsync(RatingsParameters parameters);

        Task<RatingResponse> GetByIdAsync(int id);

        Task InsertAsync(RatingRequest request);

        Task UpdateAsync(RatingRequest request);

        Task DeleteAsync(int id);
    }
}
