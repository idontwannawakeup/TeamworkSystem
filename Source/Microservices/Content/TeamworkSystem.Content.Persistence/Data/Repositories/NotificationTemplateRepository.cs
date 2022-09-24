using TeamworkSystem.Content.Application.Interfaces.Repositories;
using TeamworkSystem.Content.Domain.Entities;
using TeamworkSystem.Content.Domain.Enums;

namespace TeamworkSystem.Content.Persistence.Data.Repositories;

public class NotificationTemplateRepository : INotificationTemplateRepository
{
    private readonly ContentDbContext _dbContext;

    public NotificationTemplateRepository(ContentDbContext dbContext) => _dbContext = dbContext;

    public async Task<NotificationTemplate> GetByIdAsync(NotificationType id)
    {
        return (await _dbContext.NotificationTemplates.FindAsync(id))!;
    }
}
