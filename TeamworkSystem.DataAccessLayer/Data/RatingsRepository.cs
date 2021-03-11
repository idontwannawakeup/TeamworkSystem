using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Models;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class RatingsRepository : GenericRepository<Rating>
    {
        protected override string TableName { get; } = "Ratings";

        public RatingsRepository(ISqlConnectionFactory sqlConnectionFactory)
            : base(sqlConnectionFactory)
        {
        }
    }
}
