using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;

namespace TeamworkSystem.Content.Application.Features.Notifications.Queries.GetTopRecentNotifications;

public class GetTopRecentNotificationsQuery : IRequest<IEnumerable<NotificationResponse>>
{
    public Guid UserId { get; set; }
}
