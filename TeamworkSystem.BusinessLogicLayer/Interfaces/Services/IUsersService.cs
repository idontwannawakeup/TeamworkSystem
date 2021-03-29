using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IUsersService
    {
        Task SignUpAsync(UserSignUpDTO userSignUpDTO);

        Task<IEnumerable<UserProfileDTO>> GetAllProfilesAsync();

        Task<UserProfileDTO> GetProfileByIdAsync(string id);

        Task DeleteAsync(string id);

        Task AddFriend(string id, string friendId);

        Task DeleteFriend(string id, string friendId);
    }
}
