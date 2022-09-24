using TeamworkSystem.Identity.People.BusinessLogic.DTO.Requests;
using TeamworkSystem.Identity.People.BusinessLogic.DTO.Responses;
using TeamworkSystem.Identity.Persistence.People.Parameters;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Identity.People.BusinessLogic.Interfaces.Services;

public interface IUsersService
{
    Task<IEnumerable<UserResponse>> GetAsync();
    Task<PagedList<UserResponse>> GetAsync(UsersParameters parameters);
    Task<UserResponse> GetByIdAsync(Guid id);
    Task<UserResponse> UpdateAsync(UserRequest request);
    Task<string> SetAvatarForUserAsync(UserAvatarRequest request);
    Task DeleteAsync(Guid id);
}
