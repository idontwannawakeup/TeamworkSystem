using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Requests;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Responses;
using TeamworkSystem.Social.DataAccess.Common.Parameters;

namespace TeamworkSystem.Social.BusinessLogic.Interfaces.Services;

public interface IFriendsService
{
    Task<PagedList<UserResponse>> GetAsync(Guid userId, FriendsParameters parameters);
    Task AddToFriendsAsync(FriendsRequest request);
    Task DeleteFromFriendsAsync(FriendsRequest request);
}
