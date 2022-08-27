using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using TeamworkSystem.IdentityServer.Settings;

namespace TeamworkSystem.IdentityServer;

public static class IdentityServerConfiguration
{
    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
    {
        new ApiScope("identity-api.read"),
        new ApiScope("identity-api.write"),
        new ApiScope("work-management-api.read"),
        new ApiScope("work-management-api.write"),
        new ApiScope("social-api.read"),
        new ApiScope("social-api.write"),
        new ApiScope("content-api.read")
    };

    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
    {
        new ApiResource("identity-api")
        {
            Scopes = { "identity-api.read", "identity-api.write" },
            UserClaims = { JwtClaimTypes.Name }
        },
        new ApiResource("work-management-api")
        {
            Scopes = { "work-management-api.read", "work-management-api.write" },
            UserClaims = { JwtClaimTypes.Name }
        },
        new ApiResource("social-api")
        {
            Scopes = { "social-api.read", "social-api.write" },
            UserClaims = { JwtClaimTypes.Name }
        },
        new ApiResource("content-api")
        {
            Scopes = { "content-api.read" },
            UserClaims = { JwtClaimTypes.Name }
        }
    };

    public static IEnumerable<Client> Clients(DevClientSettings settings) => new List<Client>
    {
        new Client
        {
            ClientId = "teamwork-system-dev-client",
            ClientName = "TeamworkSystem Dev Client",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowAccessTokensViaBrowser = true,
            ClientSecrets = { new Secret(settings.Secret.Sha256()) },
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "identity-api.read",
                "identity-api.write",
                "work-management-api.read",
                "work-management-api.write",
                "social-api.read",
                "social-api.write",
                "content-api.read"
            }
        }
    };
}
