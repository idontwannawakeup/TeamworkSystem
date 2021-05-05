using System.Net.Http;
using TeamworkSystem.WebClient.Interfaces;

namespace TeamworkSystem.WebClient.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient httpClient;

        public UsersService(HttpClient httpClient) =>
            this.httpClient = httpClient;
    }
}
