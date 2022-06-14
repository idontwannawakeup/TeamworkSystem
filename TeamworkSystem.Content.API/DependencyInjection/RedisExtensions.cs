using StackExchange.Redis;

namespace TeamworkSystem.Content.API.DependencyInjection;

public static class RedisExtensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services)
    {
        var configurationOptions = new ConfigurationOptions
        {
            EndPoints = { "localhost:6379" },
            Ssl = false
        };

        services.AddStackExchangeRedisCache(options =>
                    options.ConfigurationOptions = configurationOptions)
                .BuildServiceProvider();

        return services;
    }
}
