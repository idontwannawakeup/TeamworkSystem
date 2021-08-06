using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<JwtResponse> SignInAsync(UserSignInRequest request);
        Task<JwtResponse> SignUpAsync(UserSignUpRequest request);
    }
}
