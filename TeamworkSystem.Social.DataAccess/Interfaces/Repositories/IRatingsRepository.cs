using TeamworkSystem.Shared.Interfaces;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.DataAccess.Interfaces.Repositories;

public interface IRatingsRepository : IRepository<Rating>
{
    Task<PagedList<Rating>> GetAsync(RatingsParameters parameters);
    Task<IEnumerable<Rating>> GetRatingsFromUserAsync(string userId);
    Task<IEnumerable<Rating>> GetRatingsForUserAsync(string userId);
}
