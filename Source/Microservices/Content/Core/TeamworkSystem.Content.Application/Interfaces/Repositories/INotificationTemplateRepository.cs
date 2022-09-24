using TeamworkSystem.Content.Domain.Entities;
using TeamworkSystem.Content.Domain.Enums;

namespace TeamworkSystem.Content.Application.Interfaces.Repositories;

public interface INotificationTemplateRepository
{
    Task<NotificationTemplate> GetByIdAsync(NotificationType id);
}
