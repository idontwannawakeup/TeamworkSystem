using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface IRatingsRepository : IRepository<Rating>
    {
        Task<PagedList<Rating>> GetAsync(RatingsParameters parameters);

        Task<Rating> GetCompleteRatingAsync(int id);

        Task<IEnumerable<Rating>> GetRatingsFromUserAsync(string userId);

        Task<IEnumerable<Rating>> GetRatingsForUserAsync(string userId);
    }
}
