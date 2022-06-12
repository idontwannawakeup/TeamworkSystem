using AutoMapper;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.API.Configurations;

public class UserEventsMapping : Profile
{
    public UserEventsMapping()
    {
        CreateMap<UserCreatedEvent, UserProfile>()
            .ForMember(profile => profile.Avatar, configuration => configuration.Ignore());
    }
}
