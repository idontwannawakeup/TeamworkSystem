using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Content.Application.Interfaces.Data.Repositories;
using TeamworkSystem.Content.Domain.Entities;
using TeamworkSystem.Shared.Exceptions;

namespace TeamworkSystem.Content.Persistence.Data.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly ContentDbContext _dbContext;

    public NotificationRepository(ContentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Notification>> GetAsync(Guid userId)
    {
        return await _dbContext.Notifications
                             .Where(notification => notification.NotifiedUserId == userId)
                             .ToListAsync();
    }

    public async Task<IEnumerable<Notification>> GetTopRecentAsync(Guid userId)
    {
        return await _dbContext.Notifications
                             .Where(notification => notification.NotifiedUserId == userId)
                             .OrderByDescending(notification => notification.NotifiedAt)
                             .Take(5)
                             .ToListAsync();
    }

    public Task<Notification> InsertAsync(Notification notification)
    {
        var insertedNotification = _dbContext.Notifications.Add(notification);
        return Task.FromResult(insertedNotification.Entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var notification = await _dbContext.Notifications.FindAsync(id)
                           ?? throw new EntityNotFoundException(
                               $"{nameof(Notification)} with id {id} not found.");

        _dbContext.Notifications.Remove(notification);
    }
}
