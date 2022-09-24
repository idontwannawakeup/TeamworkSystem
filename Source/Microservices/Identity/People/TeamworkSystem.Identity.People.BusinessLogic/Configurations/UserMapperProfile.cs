using AutoMapper;
using TeamworkSystem.Identity.People.BusinessLogic.DTO.Requests;
using TeamworkSystem.Identity.People.BusinessLogic.DTO.Responses;
using TeamworkSystem.Identity.Persistence.People.Entities;

namespace TeamworkSystem.Identity.People.BusinessLogic.Configurations;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserSignUpRequest, User>();
        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>()
            .ForMember(
                response => response.FullName,
                options => options.MapFrom(user => $"{user.FirstName} {user.LastName}"))
            .ForMember(
                response => response.Avatar,
                options => options.MapFrom(user => !string.IsNullOrWhiteSpace(user.Avatar)
                    ? $"IdentityService/Public/Photos/{user.Avatar}"
                    : null));
    }
}
