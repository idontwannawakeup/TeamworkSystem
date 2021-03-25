using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class ProjectsRepository
        : GenericRepository<Project>, IProjectsRepository
    {
        public async Task<Project> GetCompleteProjectAsync(int id)
        {
            return await this.table
                .Include(project => project.Team)
                .Include(project => project.Tickets)
                .SingleOrDefaultAsync(project => project.Id == id);
        }

        public async Task<Team> GetRelatedTeamAsync(int id)
        {
            Project project = await this.table
                .Include(rating => rating.Team)
                .SingleOrDefaultAsync(rating => rating.Id == id);

            return project?.Team ?? throw new Exception($"{typeof(Project).Name} not found.");
        }

        public ProjectsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
