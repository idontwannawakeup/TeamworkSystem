using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.BusinessLogic.DTO.Requests;
using TeamworkSystem.Social.BusinessLogic.DTO.Responses;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.BusinessLogic.Interfaces.Services;

public interface IRatingsService
{
    Task<IEnumerable<RatingResponse>> GetAsync();
    Task<PagedList<RatingResponse>> GetAsync(RatingsParameters parameters);
    Task<RatingResponse> GetByIdAsync(int id);
    Task InsertAsync(RatingRequest request);
    Task UpdateAsync(RatingRequest request);
    Task DeleteAsync(int id);
}
