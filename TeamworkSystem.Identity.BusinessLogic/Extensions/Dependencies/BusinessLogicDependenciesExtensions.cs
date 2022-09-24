using Microsoft.Extensions.DependencyInjection;

namespace TeamworkSystem.Identity.BusinessLogic.Extensions.Dependencies;

public static class BusinessLogicDependenciesExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddServices();
        services.AddValidation();
        return services;
    }
}
