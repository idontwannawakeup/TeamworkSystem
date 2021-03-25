using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();

        Task<UserDTO> GetByIdAsync(string id);

        Task CreateAsync(UserDTO userDTO);

        Task DeleteAsync(string id);

        Task AddFriend(string id, string friendId);

        Task DeleteFriend(string id, string friendId);
    }
}
