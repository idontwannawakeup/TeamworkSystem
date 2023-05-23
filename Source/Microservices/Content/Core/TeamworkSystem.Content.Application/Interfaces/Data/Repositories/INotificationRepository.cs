using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Application.Interfaces.Data.Repositories;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetAsync(Guid userId);
    Task<IEnumerable<Notification>> GetTopRecentAsync(Guid userId);
    Task<Notification> InsertAsync(Notification notification);
    Task DeleteAsync(Guid id);
}
