using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Requests;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Responses;
using TeamworkSystem.Social.DataAccess.Common.Parameters;

namespace TeamworkSystem.Social.BusinessLogic.Interfaces.Services;

public interface IRatingsService
{
    Task<IEnumerable<RatingResponse>> GetAsync();
    Task<PagedList<RatingResponse>> GetAsync(RatingsParameters parameters);
    Task<RatingResponse> GetByIdAsync(Guid id);
    Task InsertAsync(RatingRequest request);
    Task UpdateAsync(RatingRequest request);
    Task DeleteAsync(Guid id);
}
