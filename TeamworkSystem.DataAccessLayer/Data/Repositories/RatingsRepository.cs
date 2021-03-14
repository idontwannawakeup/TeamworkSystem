using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class RatingsRepository
        : GenericRepository<Rating>, IRatingsRepository
    {
        public RatingsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
