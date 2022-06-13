using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Application.Interfaces.Repositories;

public interface IRecentProjectRepository
{
    Task<IEnumerable<RecentProject>> GetAsync();
    Task InsertAsync(RecentProject recentProject);
}
