using MassTransit;
using TeamworkSystem.Social.API.Consumers;

namespace TeamworkSystem.Social.API.DependencyInjection;

public static class PresentationExtensions
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTwsAuthentication(configuration);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddMassTransit(massTransitConfiguration =>
        {
            massTransitConfiguration.AddConsumer<UserCreatedEventConsumer>();
            massTransitConfiguration.AddConsumer<UserChangedEventConsumer>();
            massTransitConfiguration.AddConsumer<UserAvatarChangedEventConsumer>();

            massTransitConfiguration.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(configuration["EventBusSettings:HostAddress"]);
                configurator.ReceiveEndpoint(
                    "social-user-created",
                    endpointConfigurator =>
                    {
                        endpointConfigurator.ConfigureConsumer<UserCreatedEventConsumer>(context);
                    });

                configurator.ReceiveEndpoint(
                    "social-user-changed",
                    endpointConfigurator =>
                    {
                        endpointConfigurator.ConfigureConsumer<UserChangedEventConsumer>(context);
                    });

                configurator.ReceiveEndpoint(
                    "social-user-avatar-changed",
                    endpointConfigurator =>
                    {
                        endpointConfigurator.ConfigureConsumer<UserAvatarChangedEventConsumer>(context);
                    });
            });
        });

        return services;
    }
}
