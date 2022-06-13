using TeamworkSystem.Content.Application.Interfaces.Repositories;

namespace TeamworkSystem.Content.Application;

public interface IUnitOfWork
{
    public INotificationRepository NotificationRepository { get; }
    public INotificationTemplateRepository NotificationTemplateRepository { get; }
    public IRecentRequestRepository RecentRequestRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
