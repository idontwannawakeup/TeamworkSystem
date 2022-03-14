using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Interfaces.Repositories;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Exceptions;
using TeamworkSystem.Shared.Extensions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Core.DataAccess.Data.Repositories;

public class ProjectsRepository : GenericRepository<Project>, IProjectsRepository
{
    private readonly IFilterFactory<Project> _filter;

    public ProjectsRepository(TeamworkSystemCoreDbContext databaseContext, IFilterFactory<Project> filter)
        : base(databaseContext) => _filter = filter;

    public override async Task<Project> GetCompleteEntityAsync(Guid id)
    {
        var project = await Table.Include(project => project.Team)
                                 .Include(project => project.Tickets)
                                 .SingleOrDefaultAsync(project => project.Id == id);

        return project ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }

    public async Task<PagedList<Project>> GetAsync(ProjectsParameters parameters)
    {
        IQueryable<Project> source = Table.Include(project => project.Team)
                                          .FilterWith(_filter.Get(parameters));

        return await PagedList<Project>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Team> GetRelatedTeamAsync(Guid id)
    {
        var project = await Table.Include(project => project.Team)
                                 .SingleOrDefaultAsync(project => project.Id == id);

        return project?.Team
               ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }
}
