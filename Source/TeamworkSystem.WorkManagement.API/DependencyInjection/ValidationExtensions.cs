using FluentValidation;
using FluentValidation.AspNetCore;
using TeamworkSystem.WorkManagement.Application.Common.Validation;

namespace TeamworkSystem.WorkManagement.API.DependencyInjection;

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
