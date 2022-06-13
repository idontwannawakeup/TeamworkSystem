using AutoMapper;
using TeamworkSystem.Content.Application.Common.Responses;
using TeamworkSystem.Content.Application.Notifications.Commands.SendNotification;
using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Application.Common.Mapping;

public class NotificationMapping : Profile
{
    public NotificationMapping()
    {
        CreateMap<SendNotificationCommand, Notification>();
        CreateMap<Notification, NotificationResponse>();
    }
}
