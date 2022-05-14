using AutoMapper;
using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Core.DataAccess.Entities;

namespace TeamworkSystem.Core.BusinessLogic.Configurations;

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
