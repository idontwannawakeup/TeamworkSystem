using AutoMapper;
using TeamworkSystem.WorkManagement.API.Grpc.Definitions;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.API.Common.Mapping;

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
                options => options.MapFrom(p => p.TeamId.ToString()))
            .ForMember(
                response => response.Type,
                options => options.MapFrom(p => p.Type ?? string.Empty))
            .ForMember(
                response => response.Url,
                options => options.MapFrom(p => p.Url ?? string.Empty))
            .ForMember(
                response => response.Description,
                options => options.MapFrom(p => p.Description ?? string.Empty));
    }
}
