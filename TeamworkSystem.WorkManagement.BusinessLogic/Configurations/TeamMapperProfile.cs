using AutoMapper;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Requests;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Responses;
using TeamworkSystem.WorkManagement.DataAccess.Entities;

namespace TeamworkSystem.WorkManagement.BusinessLogic.Configurations;

public class TeamMapperProfile : Profile
{
    public TeamMapperProfile()
    {
        CreateMap<TeamRequest, Team>();
        CreateMap<Team, TeamResponse>()
            .ForMember(response => response.Avatar,
                options => options.MapFrom(
                    team => !string.IsNullOrWhiteSpace(team.Avatar)
                        ? $"CoreService/Public/Photos/{team.Avatar}"
                        : null));
    }
}
