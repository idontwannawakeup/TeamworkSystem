using StackExchange.Redis;

namespace TeamworkSystem.Content.API.DependencyInjection;

public static class RedisExtensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        var configurationOptions = new ConfigurationOptions
        {
            EndPoints = { configuration["CacheSettings:RedisConnectionString"] },
            Ssl = false
        };

        services.AddStackExchangeRedisCache(options =>
                    options.ConfigurationOptions = configurationOptions)
                .BuildServiceProvider();

        return services;
    }
}
