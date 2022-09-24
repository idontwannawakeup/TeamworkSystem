using AutoMapper;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.Identity.People.BusinessLogic.Common.Models.Requests;
using TeamworkSystem.Identity.People.BusinessLogic.Common.Models.Responses;

namespace TeamworkSystem.Identity.People.API.Common.Mapping;

public class UserEventsMapping : Profile
{
    public UserEventsMapping()
    {
        CreateMap<UserSignUpRequest, UserCreatedEvent>();
        CreateMap<UserResponse, UserChangedEvent>();
    }
}
