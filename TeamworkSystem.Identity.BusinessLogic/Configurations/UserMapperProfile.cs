using AutoMapper;
using TeamworkSystem.Identity.BusinessLogic.DTO.Requests;
using TeamworkSystem.Identity.BusinessLogic.DTO.Responses;
using TeamworkSystem.Identity.DataAccess.Entities;

namespace TeamworkSystem.Identity.BusinessLogic.Configurations;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserSignUpRequest, User>();
        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>()
            .ForMember(response => response.FullName,
                options => options.MapFrom(user => $"{user.FirstName} {user.LastName}"))
            .ForMember(response => response.Avatar,
                options => options.MapFrom(
                    user => !string.IsNullOrWhiteSpace(user.Avatar)
                        ? $"Public/Photos/{user.Avatar}"
                        : null));
    }
}
