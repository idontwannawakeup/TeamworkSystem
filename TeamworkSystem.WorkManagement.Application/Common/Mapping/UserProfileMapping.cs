using AutoMapper;
using TeamworkSystem.WorkManagement.Application.Common.Responses;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Common.Mapping;

public class UserProfileMapping : Profile
{
    public UserProfileMapping()
    {
        CreateMap<UserProfile, UserResponse>()
            .ForMember(
                user => user.FullName,
                options => options.MapFrom(user => $"{user.FirstName} {user.LastName}"));
    }
}
