using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.DataAccess.Common.Parameters;
using TeamworkSystem.Social.DataAccess.Data.Entities;

namespace TeamworkSystem.Social.DataAccess.Interfaces.Data.Repositories;

public interface IFriendsRepository
{
    Task<IEnumerable<UserProfile>> GetAsync(Guid userId);
    Task<PagedList<UserProfile>> GetAsync(Guid userId, FriendsParameters parameters);
    Task AddToFriendsAsync(Guid firstId, Guid secondId);
    Task DeleteFromFriendsAsync(Guid firstId, Guid secondId);
}
