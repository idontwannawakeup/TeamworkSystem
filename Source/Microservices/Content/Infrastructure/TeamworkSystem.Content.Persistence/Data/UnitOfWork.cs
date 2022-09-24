using TeamworkSystem.Content.Application.Interfaces.Data;
using TeamworkSystem.Content.Application.Interfaces.Data.Repositories;

namespace TeamworkSystem.Content.Persistence.Data;

public class UnitOfWork : IUnitOfWork
{
    protected readonly ContentDbContext DatabaseContext;

    public UnitOfWork(
        ContentDbContext databaseContext,
        INotificationRepository notificationRepository,
        INotificationTemplateRepository notificationTemplateRepository,
        IRecentRequestRepository recentRequestRepository)
    {
        DatabaseContext = databaseContext;
        NotificationRepository = notificationRepository;
        NotificationTemplateRepository = notificationTemplateRepository;
        RecentRequestRepository = recentRequestRepository;
    }

    public INotificationRepository NotificationRepository { get; }
    public INotificationTemplateRepository NotificationTemplateRepository { get; }
    public IRecentRequestRepository RecentRequestRepository { get; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await DatabaseContext.SaveChangesAsync(cancellationToken);
}
