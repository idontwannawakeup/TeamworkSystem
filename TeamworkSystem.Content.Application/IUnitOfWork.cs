using TeamworkSystem.Content.Application.Interfaces.Repositories;

namespace TeamworkSystem.Content.Application;

public interface IUnitOfWork
{
    public INotificationRepository NotificationRepository { get; }
    public INotificationTemplateRepository NotificationTemplateRepository { get; }
    public IRecentProjectRepository RecentProjectRepository { get; }
    public IRecentTeamRepository RecentTeamRepository { get; }
    public IRecentTicketRepository RecentTicketRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
