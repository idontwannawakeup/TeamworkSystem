using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Application.Interfaces.Repositories;

public interface IRecentTeamRepository
{
    Task<IEnumerable<RecentTeam>> GetAsync();
    Task InsertAsync(RecentTeam recentTeam);
}
