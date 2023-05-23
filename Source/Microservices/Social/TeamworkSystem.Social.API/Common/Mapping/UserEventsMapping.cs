using AutoMapper;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.Social.DataAccess.Data.Entities;

namespace TeamworkSystem.Social.API.Common.Mapping;

public class UserEventsMapping : Profile
{
    public UserEventsMapping()
    {
        CreateMap<UserCreatedEvent, UserProfile>()
            .ForMember(profile => profile.Avatar, configuration => configuration.Ignore());
    }
}
