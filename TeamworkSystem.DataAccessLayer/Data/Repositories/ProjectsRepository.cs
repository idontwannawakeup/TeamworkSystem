using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Extensions;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories;

public class ProjectsRepository : GenericRepository<Project>, IProjectsRepository
{
    private readonly IFilterFactory<Project> _filter;

    public ProjectsRepository(TeamworkSystemContext databaseContext, IFilterFactory<Project> filter)
        : base(databaseContext) => _filter = filter;

    public override async Task<Project> GetCompleteEntityAsync(int id)
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

    public async Task<Team> GetRelatedTeamAsync(int id)
    {
        var project = await Table.Include(project => project.Team)
                                 .SingleOrDefaultAsync(project => project.Id == id);

        return project?.Team ??
               throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }
}
