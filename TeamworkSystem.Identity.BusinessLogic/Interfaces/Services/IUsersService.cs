using TeamworkSystem.Identity.BusinessLogic.DTO.Requests;
using TeamworkSystem.Identity.BusinessLogic.DTO.Responses;
using TeamworkSystem.Identity.DataAccess.Parameters;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Identity.BusinessLogic.Interfaces.Services;

public interface IUsersService
{
    Task<IEnumerable<UserResponse>> GetAsync();
    Task<PagedList<UserResponse>> GetAsync(UsersParameters parameters);
    Task<UserResponse> GetByIdAsync(Guid id);
    Task<PagedList<UserResponse>> GetFriendsAsync(Guid id, UsersParameters parameters);
    Task UpdateAsync(UserRequest request);
    Task SetAvatarForUserAsync(UserAvatarRequest request);
    Task DeleteAsync(Guid id);
    Task AddFriendAsync(FriendsRequest friendsRequest);
    Task DeleteFriendAsync(FriendsRequest friendsRequest);
}
