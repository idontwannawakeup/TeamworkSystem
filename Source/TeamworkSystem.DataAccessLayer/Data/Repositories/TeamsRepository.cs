using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Extensions;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories;

public class TeamsRepository : GenericRepository<Team>, ITeamsRepository
{
    private readonly IFilterFactory<Team> _filter;

    public TeamsRepository(TeamworkSystemContext databaseContext, IFilterFactory<Team> filter) :
        base(databaseContext) => _filter = filter;

    public override async Task<Team> GetCompleteEntityAsync(int id)
    {
        var team = await Table.Include(team => team.Leader)
                              .Include(team => team.Projects)
                              .Include(team => team.Members)
                              .SingleOrDefaultAsync(team => team.Id == id);

        return team ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }

    public async Task<PagedList<Team>> GetAsync(TeamsParameters parameters)
    {
        IQueryable<Team> source = Table.Include(team => team.Leader)
                                       .FilterWith(_filter.Get(parameters));

        return await PagedList<Team>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<IEnumerable<Team>> GetUserTeams(User user) =>
        await Table.Where(team => team.Members.Contains(user)).ToListAsync();

    public async Task<IEnumerable<User>> GetMembersAsync(int id)
    {
        var team = await Table.Include(team => team.Members)
                              .SingleOrDefaultAsync(team => team.Id == id);

        if (team is null)
        {
            throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        return team.Members;
    }

    public async Task AddMemberAsync(int id, User member)
    {
        var team = await Table.Include(team => team.Members)
                              .SingleOrDefaultAsync(team => team.Id == id);

        if (team is null)
        {
            throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        team.Members.Add(member);
    }

    public async Task DeleteMemberAsync(int id, User member)
    {
        var team = await Table.Include(team => team.Members)
                              .SingleOrDefaultAsync(team => team.Id == id);

        if (team is null)
        {
            throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        team.Members.Remove(member);
    }
}
