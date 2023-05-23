using TeamworkSystem.Content.Domain.Entities;
using TeamworkSystem.Content.Domain.Enums;

namespace TeamworkSystem.Content.Application.Interfaces.Data.Repositories;

public interface IRecentRequestRepository
{
    Task<IEnumerable<RecentRequest>> GetAsync(Guid userId, RecentRequestEntityType type);
    Task InsertAsync(RecentRequest recentRequest);
}
