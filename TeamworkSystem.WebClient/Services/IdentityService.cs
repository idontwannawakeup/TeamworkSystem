using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Exceptions;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Factories;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient httpClient;

        public async Task<JwtViewModel> SignInAsync(UserSignInViewModel viewModel) =>
            await ExecuteQueryAsync("signIn", viewModel);

        public async Task<JwtViewModel> SignUpAsync(UserSignUpViewModel viewModel) =>
            await ExecuteQueryAsync("signUp", viewModel);

        private async Task<JwtViewModel> ExecuteQueryAsync<T>(string requestUri, T model)
        {
            var response = await httpClient.PostAsync(
                requestUri,
                StringContentFactory.BuildStringContent(model.Serialize()));

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var validationErrorModel = responseBody.Deserialize<ValidationErrorViewModel>();
                throw new ValidationException(validationErrorModel.Errors);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                var errorModel = responseBody.Deserialize<ErrorViewModel>();
                throw new Exception(errorModel.Message);
            }

            return responseBody.Deserialize<JwtViewModel>();
        }

        public IdentityService(HttpClient httpClient) =>
            this.httpClient = httpClient;
    }
}
