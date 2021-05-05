using System.Threading.Tasks;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface IIdentityService
    {
        Task<JwtViewModel> SignInAsync(UserSignInViewModel viewModel);
    }
}
