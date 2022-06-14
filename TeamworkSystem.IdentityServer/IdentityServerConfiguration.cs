using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace TeamworkSystem.IdentityServer;

public class IdentityServerConfiguration
{
    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
    {
        new ApiScope("IdentityAPI", "Work Management API"),
        new ApiScope("WorkManagementAPI", "Work Management API"),
        new ApiScope("SocialAPI", "Social API"),
        new ApiScope("ContentAPI", "Content API")
    };

    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
    {
        new ApiResource("IdentityAPI", "Identity API", new[] { JwtClaimTypes.Name })
        {
            Scopes = { "IdentityAPI" }
        },
        new ApiResource("WorkManagementAPI", "Work Management API", new[] { JwtClaimTypes.Name })
        {
            Scopes = { "WorkManagementAPI" }
        },
        new ApiResource("SocialAPI", "Social API", new[] { JwtClaimTypes.Name })
        {
            Scopes = { "SocialAPI" }
        },
        new ApiResource("ContentAPI", "Content API", new[] { JwtClaimTypes.Name })
        {
            Scopes = { "ContentAPI" }
        }
    };

    public static IEnumerable<Client> Clients => new List<Client>
    {
        new Client
        {
            ClientId = "teamwork-system-web-client",
            ClientName = "TeamworkSystem Web Client",
            AllowedGrantTypes = GrantTypes.Code,
            RequireClientSecret = false,
            RequirePkce = true,
            RedirectUris =
            {
                "https://.../signin-oidc"
            },
            AllowedCorsOrigins =
            {
                "https://..."
            },
            PostLogoutRedirectUris =
            {
                "https:/.../signout-oidc"
            },
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "WorkManagementAPI",
                "SocialAPI",
                "ContentAPI"
            },
            AllowAccessTokensViaBrowser = true
        }
    };
}
