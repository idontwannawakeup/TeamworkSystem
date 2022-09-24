using AutoMapper;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.Identity.People.BusinessLogic.DTO.Requests;
using TeamworkSystem.Identity.People.BusinessLogic.DTO.Responses;

namespace TeamworkSystem.Identity.People.API.Configurations;

public class UserEventsMapping : Profile
{
    public UserEventsMapping()
    {
        CreateMap<UserSignUpRequest, UserCreatedEvent>();
        CreateMap<UserResponse, UserChangedEvent>();
    }
}
