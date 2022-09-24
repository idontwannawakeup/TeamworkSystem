using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.BusinessLogic.Validation;

namespace TeamworkSystem.Identity.BusinessLogic.Extensions.Dependencies;

public static class ValidationDependenciesExtensions
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
        services.AddControllers()
                .AddFluentValidation(configuration =>
                    configuration.RegisterValidatorsFromAssemblyContaining<ValidationDependencyInjection>());

        return services;
    }
}
