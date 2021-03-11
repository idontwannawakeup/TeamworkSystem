using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Models;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class TeamsRepository : GenericRepository<Team>
    {
        protected override string TableName { get; } = "Teams";
        
        public TeamsRepository(ISqlConnectionFactory sqlConnectionFactory)
            : base(sqlConnectionFactory)
        {
        }
    }
}
