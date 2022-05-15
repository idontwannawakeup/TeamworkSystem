using AutoMapper;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Responses;
using TeamworkSystem.WorkManagement.DataAccess.Entities;

namespace TeamworkSystem.WorkManagement.BusinessLogic.Configurations;

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
                        ? $"IdentityService/Public/Photos/{user.Avatar}"
                        : null));
    }
}
