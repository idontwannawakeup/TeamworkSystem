using MediatR;
using TeamworkSystem.Content.Application.Common.Models.Responses;

namespace TeamworkSystem.Content.Application.Features.Notifications.Queries.GetNotifications;

public class GetNotificationsQuery : IRequest<IEnumerable<NotificationResponse>>
{
    public Guid UserId { get; set; }
}
