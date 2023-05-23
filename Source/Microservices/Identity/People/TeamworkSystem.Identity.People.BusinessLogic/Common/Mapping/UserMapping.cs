using AutoMapper;
using TeamworkSystem.Identity.People.BusinessLogic.Common.Models.Requests;
using TeamworkSystem.Identity.People.BusinessLogic.Common.Models.Responses;
using TeamworkSystem.Identity.Persistence.People.Data.Entities;

namespace TeamworkSystem.Identity.People.BusinessLogic.Common.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
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
