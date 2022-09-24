using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TeamworkSystem.Social.API.DependencyInjection;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddTwsAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(
                    JwtBearerDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.ApiName = "social-api";
                        options.Authority = configuration["AuthenticationAuthorityUrl"];
                    });

        return services;
    }
}
