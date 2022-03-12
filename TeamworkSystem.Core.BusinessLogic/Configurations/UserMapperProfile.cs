using AutoMapper;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Core.DataAccess.Entities;

namespace TeamworkSystem.Core.BusinessLogic.Configurations;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserProfile, UserResponse>()
            .ForMember(response => response.FullName,
                options => options.MapFrom(user => $"{user.FirstName} {user.LastName}"))
            .ForMember(response => response.Avatar,
                options => options.MapFrom(
                    user => !string.IsNullOrWhiteSpace(user.Avatar)
                        ? $"Public/Photos/{user.Avatar}"
                        : null));
    }
}
