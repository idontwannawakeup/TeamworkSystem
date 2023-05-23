using AutoMapper;
using TeamworkSystem.Content.Application.Common.Models.Responses;
using TeamworkSystem.Content.Application.Features.Notifications.Commands.SendNotification;
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
