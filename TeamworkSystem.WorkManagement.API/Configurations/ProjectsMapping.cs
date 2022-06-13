using AutoMapper;
using TeamworkSystem.WorkManagement.API.Grpc.Definitions;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.API.Configurations;

public class ProjectsMapping : Profile
{
    public ProjectsMapping()
    {
        CreateMap<Project, GetRecentProjectResponse>()
            .ForMember(
                response => response.Id,
                options => options.MapFrom(p => p.Id.ToString()))
            .ForMember(
                response => response.TeamId,
                options => options.MapFrom(p => p.TeamId.ToString()));
    }
}
