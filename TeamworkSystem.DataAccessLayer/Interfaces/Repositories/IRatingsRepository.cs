using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface IRatingsRepository : IRepository<Rating>
    {
        Task<Rating> GetCompleteRatingAsync(int id);
    }
}
