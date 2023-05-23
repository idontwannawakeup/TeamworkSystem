using AutoMapper;
using TeamworkSystem.Content.Application.Common.Models.Responses;
using TeamworkSystem.Content.Application.Grpc.Definitions;

namespace TeamworkSystem.Content.Application.Common.Mapping;

public class ProjectMapping : Profile
{
    public ProjectMapping()
    {
        CreateMap<GetRecentProjectResponse, ProjectResponse>()
            .ForMember(
                response => response.Id,
                options => options.MapFrom(p => Guid.Parse(p.Id)))
            .ForMember(
                response => response.TeamId,
                options => options.MapFrom(p => Guid.Parse(p.TeamId)));
    }
}
