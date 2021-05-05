using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Factories;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient httpClient;

        public async Task<JwtViewModel> SignInAsync(UserSignInViewModel viewModel)
        {
            viewModel.UserName = "User2";
            viewModel.Password = "User%password2";

            var response = await httpClient.PostAsync(
                "signIn",
                StringContentFactory.BuildStringContent(viewModel.Serialize()));

            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<JwtViewModel>();
        }

        public IdentityService(HttpClient httpClient) =>
            this.httpClient = httpClient;
    }
}
