using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TeamworkSystem.Identity.BusinessLogic.Configurations;
using TeamworkSystem.Identity.BusinessLogic.Factories;
using TeamworkSystem.Identity.BusinessLogic.Interfaces;

namespace TeamworkSystem.Identity.BusinessLogic.DependencyInjection;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddAuthenticationWithJwtBearer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"])),
                        ClockSkew = TimeSpan.Zero,
                    };
                });

        services.AddTransient<JwtTokenConfiguration>();
        services.AddTransient<IJwtSecurityTokenFactory, JwtSecurityTokenFactory>();

        return services;
    }
}
