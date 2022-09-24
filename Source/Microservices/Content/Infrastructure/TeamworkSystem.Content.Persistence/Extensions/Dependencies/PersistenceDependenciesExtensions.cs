using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Content.Application.Interfaces.Data;
using TeamworkSystem.Content.Application.Interfaces.Data.Repositories;
using TeamworkSystem.Content.Persistence.Data;
using TeamworkSystem.Content.Persistence.Data.Repositories;

namespace TeamworkSystem.Content.Persistence.Extensions.Dependencies;

public static class PersistenceDependenciesExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ContentDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<INotificationRepository, NotificationRepository>();
        services.AddTransient<INotificationTemplateRepository, NotificationTemplateRepository>();
        services.AddTransient<IRecentRequestRepository, RecentRequestRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
