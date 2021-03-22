using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class RatingsRepository
        : GenericRepository<Rating>, IRatingsRepository
    {
        public async Task<Rating> GetCompleteRatingAsync(int id)
        {
            return await this.table
                .Include(rating => rating.From)
                .Include(rating => rating.To)
                .SingleOrDefaultAsync(rating => rating.Id == id);
        }

        public RatingsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
