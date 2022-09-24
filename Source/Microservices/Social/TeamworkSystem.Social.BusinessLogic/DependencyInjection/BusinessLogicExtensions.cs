using Microsoft.Extensions.DependencyInjection;

namespace TeamworkSystem.Social.BusinessLogic.DependencyInjection;

public static class BusinessLogicExtensions
{
    public static IServiceCollection AddBusinessLogic(
        this IServiceCollection services)
    {
        services.AddServices();
        services.AddValidation();
        return services;
    }
}
