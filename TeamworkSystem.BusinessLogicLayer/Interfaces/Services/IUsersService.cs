using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IUsersService
    {
        Task SignUpAsync(UserSignUpRequest userSignUpDTO);

        Task<IEnumerable<UserProfileResponse>> GetAllProfilesAsync();

        Task<UserProfileResponse> GetProfileByIdAsync(string id);

        Task DeleteAsync(string id);

        Task AddFriendAsync(FriendsRequest friendsRequest);

        Task DeleteFriendAsync(FriendsRequest friendsRequest);
    }
}
