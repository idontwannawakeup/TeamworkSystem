using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories;

public class ProjectsRepository : GenericRepository<Project>, IProjectsRepository
{
    public ProjectsRepository(TeamworkSystemContext databaseContext) : base(databaseContext)
    {
    }

    public override async Task<Project> GetCompleteEntityAsync(int id)
    {
        var project = await Table.Include(project => project.Team)
                                 .Include(project => project.Tickets)
                                 .SingleOrDefaultAsync(project => project.Id == id);

        return project ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }

    public async Task<PagedList<Project>> GetAsync(ProjectsParameters parameters)
    {
        IQueryable<Project> source = Table.Include(project => project.Team);

        SearchByTeamId(ref source, parameters.TeamId);
        SearchByTeamMemberId(ref source, parameters.TeamMemberId);
        SearchByTitle(ref source, parameters.Title);

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

    private static void SearchByTeamId(ref IQueryable<Project> source, int? teamId)
    {
        if (teamId is null or 0)
        {
            return;
        }

        source = source.Where(project => project.TeamId == teamId);
    }

    private static void SearchByTeamMemberId(ref IQueryable<Project> source,
                                             string? teamMemberId)
    {
        if (string.IsNullOrWhiteSpace(teamMemberId))
        {
            return;
        }

        source = source.Where(
            project => project.Team.Members.Any(user => user.Id == teamMemberId));
    }

    private static void SearchByTitle(ref IQueryable<Project> source, string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return;
        }

        source = source.Where(project => project.Title.Contains(title));
    }
}
