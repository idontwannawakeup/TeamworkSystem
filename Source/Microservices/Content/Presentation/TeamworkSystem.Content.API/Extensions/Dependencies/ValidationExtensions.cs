using FluentValidation;
using FluentValidation.AspNetCore;
using TeamworkSystem.Content.Application.Common.Validation;

namespace TeamworkSystem.Content.API.Extensions.Dependencies;

public static class ValidationExtensions
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
        services.AddControllers()
                .AddFluentValidation(configuration =>
                {
                    configuration.RegisterValidatorsFromAssemblyContaining<ValidationDependencyInjection>();
                });

        return services;
    }
}
