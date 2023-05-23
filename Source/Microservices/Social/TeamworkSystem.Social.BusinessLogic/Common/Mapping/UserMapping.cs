using AutoMapper;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Responses;
using TeamworkSystem.Social.DataAccess.Data.Entities;

namespace TeamworkSystem.Social.BusinessLogic.Common.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserProfile, UserResponse>()
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
