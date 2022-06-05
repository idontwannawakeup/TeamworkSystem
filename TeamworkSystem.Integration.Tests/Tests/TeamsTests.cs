using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.DataAccessLayer;
using TeamworkSystem.Integration.Tests.Configuration;

namespace TeamworkSystem.Integration.Tests.Tests;

public class TeamsTests
{
    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private WebApplicationFactory<Program> _webApplicationFactory = default!;
    private HttpClient _client = default!;

    [SetUp]
    public async Task Initialize()
    {
        _webApplicationFactory = WebApplicationFactoryConfiguration.GetConfiguredApplication();
        _client = _webApplicationFactory.CreateClient();

        await using var scope = _webApplicationFactory.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<TeamworkSystemContext>();
        await context.Database.EnsureCreatedAsync();
    }

    [TearDown]
    public async Task Finish()
    {
        await using var scope = _webApplicationFactory.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<TeamworkSystemContext>();
        await context.Database.EnsureDeletedAsync();
        await context.DisposeAsync();
    }

    [TestCase]
    public async Task GetTeams_WhenCalledWithValidToken_ShouldReturnOk()
    {
        const string identityEndpoint = "api/Identity/signIn";
        const string endpoint = "api/Teams";
        const HttpStatusCode expectedStatusCode = HttpStatusCode.OK;

        var signInResult = await _client.PostAsJsonAsync(
            identityEndpoint,
            new { UserName = "User1", Password = "User%password1" },
            SerializerOptions);

        signInResult.IsSuccessStatusCode.Should().Be(true);

        var jwt = await signInResult.Content.ReadFromJsonAsync<JwtResponse>(SerializerOptions);
        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", jwt?.Token);

        var result = await _client.GetAsync(endpoint);
        var actualStatusCode = result.StatusCode;

        result.IsSuccessStatusCode.Should().Be(true);
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task GetTeams_WhenCalledWithoutToken_ShouldReturnUnauthorized()
    {
        const string endpoint = "api/Teams";
        const HttpStatusCode expectedStatusCode = HttpStatusCode.Unauthorized;

        var result = await _client.GetAsync(endpoint);
        var actualStatusCode = result.StatusCode;

        result.IsSuccessStatusCode.Should().NotBe(true);
        actualStatusCode.Should().Be(expectedStatusCode);
    }
}
