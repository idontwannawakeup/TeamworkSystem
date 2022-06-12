using AutoMapper;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.Social.DataAccess.Entities;

namespace TeamworkSystem.Social.API.Configurations;


public class UserEventsMapping : Profile
{
    public UserEventsMapping()
    {
        CreateMap<UserCreatedEvent, UserProfile>()
            .ForMember(profile => profile.Avatar, configuration => configuration.Ignore());
    }
}
