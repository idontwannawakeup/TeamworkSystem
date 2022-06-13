using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Application.Interfaces.Repositories;

public interface IRecentProjectRepository
{
    Task<IEnumerable<RecentProject>> GetAsync(Guid userId);
    Task InsertAsync(RecentProject recentProject);
}
