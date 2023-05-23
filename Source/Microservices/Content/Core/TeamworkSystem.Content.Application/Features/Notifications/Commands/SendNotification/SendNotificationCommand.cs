using MediatR;

namespace TeamworkSystem.Content.Application.Features.Notifications.Commands.SendNotification;

public class SendNotificationCommand : IRequest
{
    public Guid NotifiedUserId { get; set; }

    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public DateTime NotifiedAt { get; set; }
}
