using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Models;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class ProjectsRepository : GenericRepository<Project>
    {
        protected override string TableName { get; } = "Projects";
        
        public ProjectsRepository(ISqlConnectionFactory sqlConnectionFactory)
            : base(sqlConnectionFactory)
        {
        }
    }
}