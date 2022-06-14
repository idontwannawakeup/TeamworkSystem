using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;

namespace TeamworkSystem.Content.Application.Notifications.Queries.GetNotifications;

public class GetNotificationsQuery : IRequest<IEnumerable<NotificationResponse>>
{
    public Guid UserId { get; set; }
}
