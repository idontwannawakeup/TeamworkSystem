using TeamworkSystem.Identity.BusinessLogic.DTO.Requests;
using TeamworkSystem.Identity.BusinessLogic.DTO.Responses;

namespace TeamworkSystem.Identity.BusinessLogic.Interfaces.Services;

public interface IIdentityService
{
    Task<JwtResponse> SignInAsync(UserSignInRequest request);
    Task<JwtResponse> SignUpAsync(UserSignUpRequest request);
}
