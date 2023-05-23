using AutoMapper;
using TeamworkSystem.Content.Application.Common.Models.Responses;
using TeamworkSystem.Content.Application.Grpc.Definitions;

namespace TeamworkSystem.Content.Application.Common.Mapping;

public class TeamMapping : Profile
{
    public TeamMapping()
    {
        CreateMap<GetRecentTeamResponse, TeamResponse>()
            .ForMember(
                response => response.Id,
                options => options.MapFrom(t => Guid.Parse(t.Id)))
            .ForMember(
                response => response.LeaderId,
                options => options.MapFrom(t => Guid.Parse(t.Id)));
    }
}
