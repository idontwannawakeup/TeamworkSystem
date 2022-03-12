using AutoMapper;
using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Core.DataAccess.Entities;

namespace TeamworkSystem.Core.BusinessLogic.Configurations;

public class TeamMapperProfile : Profile
{
    private TeamMapperProfile()
    {
        CreateMap<TeamRequest, Team>();
        CreateMap<Team, TeamResponse>()
            .ForMember(response => response.Avatar,
                options => options.MapFrom(
                    team => !string.IsNullOrWhiteSpace(team.Avatar)
                        ? $"Public/Photos/{team.Avatar}"
                        : null));
    }
}
