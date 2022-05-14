using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ApiHttpClient _httpClient;
        private readonly ApiAuthenticationStateProvider _stateProvider;

        public async Task<JwtViewModel> SignInAsync(UserSignInViewModel viewModel) =>
            await ExecuteRequestAsync("signIn", viewModel);

        public async Task<JwtViewModel> SignUpAsync(UserSignUpViewModel viewModel) =>
            await ExecuteRequestAsync("signUp", viewModel);

        private async Task<JwtViewModel> ExecuteRequestAsync<T>(string requestUri, T model)
        {
            var jwtModel = await _httpClient.PostWithoutAuthorizationAsync<T, JwtViewModel>(
                requestUri,
                model);

            await _stateProvider.MarkUserAsAuthenticatedAsync(jwtModel.Token);
            return jwtModel;
        }

        public IdentityService(HttpClient httpClient,
                               ApiAuthenticationStateProvider stateProvider)
        {
            _httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(stateProvider)
                                                                  .Build();

            _stateProvider = stateProvider;
        }
    }
}
