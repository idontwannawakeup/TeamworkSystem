using AutoMapper;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.CreateTeam;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.UpdateTeam;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Common.Mapping;

public class TeamMapping : Profile
{
    public TeamMapping()
    {
        CreateMap<CreateTeamCommand, Team>();
        CreateMap<UpdateTeamCommand, Team>();
        CreateMap<Team, TeamResponse>()
            .ForMember(
                response => response.Avatar,
                options => options.MapFrom(
                    team => !string.IsNullOrWhiteSpace(team.Avatar)
                        ? $"CoreService/Public/Photos/{team.Avatar}"
                        : null));
    }
}
