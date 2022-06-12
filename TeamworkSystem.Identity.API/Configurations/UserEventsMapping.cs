using AutoMapper;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.Identity.BusinessLogic.DTO.Requests;
using TeamworkSystem.Identity.BusinessLogic.DTO.Responses;

namespace TeamworkSystem.Identity.API.Configurations;

public class UserEventsMapping : Profile
{
    public UserEventsMapping()
    {
        CreateMap<UserSignUpRequest, UserCreatedEvent>();
        CreateMap<UserResponse, UserChangedEvent>();
    }
}
