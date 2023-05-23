using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TeamworkSystem.WorkManagement.API.Extensions.Dependencies;

public static class AuthenticationDependenciesExtensions
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
                        options.ApiName = "work-management-api";
                        options.Authority = configuration["AuthenticationAuthorityUrl"];
                    });

        return services;
    }
}
