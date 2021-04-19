using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class ProjectsRepository
        : GenericRepository<Project>, IProjectsRepository
    {
        public override async Task<Project> GetCompleteEntityAsync(int id)
        {
            return await table
                .Include(project => project.Team)
                .Include(project => project.Tickets)
                .SingleOrDefaultAsync(project => project.Id == id)
                    ?? throw new EntityNotFoundException(
                        GetEntityNotFoundErrorMessage(id));
        }

        public async Task<PagedList<Project>> GetAsync(
            ProjectsParameters parameters)
        {
            IQueryable<Project> source = table;
            return await PagedList<Project>.ToPagedListAsync(
                source,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public async Task<Team> GetRelatedTeamAsync(int id)
        {
            var project = await table
                .Include(project => project.Team)
                .SingleOrDefaultAsync(project => project.Id == id)
                    ?? throw new EntityNotFoundException(
                        GetEntityNotFoundErrorMessage(id));

            return project?.Team;
        }

        public ProjectsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
