using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.BusinessLogic.DTO.Requests;
using TeamworkSystem.Social.BusinessLogic.DTO.Responses;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.BusinessLogic.Interfaces.Services;

public interface IFriendsService
{
    Task<PagedList<UserResponse>> GetAsync(Guid userId, FriendsParameters parameters);
    Task AddToFriendsAsync(FriendsRequest request);
    Task DeleteFromFriendsAsync(FriendsRequest request);
}
