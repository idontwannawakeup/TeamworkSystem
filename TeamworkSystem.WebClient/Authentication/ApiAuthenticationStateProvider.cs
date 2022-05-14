using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace TeamworkSystem.WebClient.Authentication
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        private static AuthenticationState AnonymousState =>
            new(new ClaimsPrincipal(new ClaimsIdentity()));

        public async Task<string> GetJwtTokenAsync() =>
            await _localStorage.GetItemAsync<string>("securityToken");

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var encryptedToken = await _localStorage.GetItemAsync<string>("securityToken");
            if (encryptedToken is null)
            {
                return AnonymousState;
            }

            var token = new JwtSecurityTokenHandler().ReadJwtToken(encryptedToken);
            return GenerateStateFromToken(token);
        }

        public async Task MarkUserAsAuthenticatedAsync(string encryptedToken)
        {
            await _localStorage.SetItemAsync("securityToken", encryptedToken);
            var token = new JwtSecurityTokenHandler().ReadJwtToken(encryptedToken);
            var state = GenerateStateFromToken(token);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }

        public async Task MarkUserAsLoggedOutAsync()
        {
            await _localStorage.RemoveItemAsync("securityToken");
            NotifyAuthenticationStateChanged(Task.FromResult(AnonymousState));
        }

        public static async Task<string> GetUserIdFromStateAsync(Task<AuthenticationState> state) =>
            (await state).User.Claims.First(claim => claim.Type == ClaimTypes.Authentication).Value;

        private static AuthenticationState GenerateStateFromToken(JwtSecurityToken token)
        {
            var identity = new ClaimsIdentity(token.Claims, "apiauth_type");
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);
        }

        public ApiAuthenticationStateProvider(ILocalStorageService localStorage) =>
            _localStorage = localStorage;
    }
}
