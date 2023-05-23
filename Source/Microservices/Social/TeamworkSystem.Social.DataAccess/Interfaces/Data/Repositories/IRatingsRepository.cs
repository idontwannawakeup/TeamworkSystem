using TeamworkSystem.Shared.Interfaces;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.DataAccess.Common.Parameters;
using TeamworkSystem.Social.DataAccess.Data.Entities;

namespace TeamworkSystem.Social.DataAccess.Interfaces.Data.Repositories;

public interface IRatingsRepository : IRepository<Rating>
{
    Task<PagedList<Rating>> GetAsync(RatingsParameters parameters);
    Task<IEnumerable<Rating>> GetRatingsFromUserAsync(Guid userId);
    Task<IEnumerable<Rating>> GetRatingsForUserAsync(Guid userId);
}
