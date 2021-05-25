using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ApiHttpClient httpClient;

        private readonly ApiAuthenticationStateProvider stateProvider;

        public async Task<JwtViewModel> SignInAsync(UserSignInViewModel viewModel) =>
            await ExecuteRequestAsync("signIn", viewModel);

        public async Task<JwtViewModel> SignUpAsync(UserSignUpViewModel viewModel) =>
            await ExecuteRequestAsync("signUp", viewModel);

        private async Task<JwtViewModel> ExecuteRequestAsync<T>(string requestUri, T model)
        {
            var jwtModel = await httpClient.PostWithoutAuthorizationAsync<T, JwtViewModel>(
                requestUri,
                model);

            await stateProvider.MarkUserAsAuthenticatedAsync(jwtModel.Token);
            return jwtModel;
        }

        public IdentityService(
            HttpClient httpClient,
            ApiAuthenticationStateProvider stateProvider)
        {
            this.httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(stateProvider)
                                                                  .Build();

            this.stateProvider = stateProvider;
        }
    }
}
