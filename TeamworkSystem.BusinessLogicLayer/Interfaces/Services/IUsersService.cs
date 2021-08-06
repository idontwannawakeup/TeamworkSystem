using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserResponse>> GetAsync();
        Task<PagedList<UserResponse>> GetAsync(UsersParameters parameters);
        Task<UserResponse> GetByIdAsync(string id);
        Task<PagedList<UserResponse>> GetFriendsAsync(string id, UsersParameters parameters);
        Task UpdateAsync(UserRequest request);
        Task SetAvatarForUserAsync(UserAvatarRequest request);
        Task DeleteAsync(string id);
        Task AddFriendAsync(FriendsRequest friendsRequest);
        Task DeleteFriendAsync(FriendsRequest friendsRequest);
    }
}
