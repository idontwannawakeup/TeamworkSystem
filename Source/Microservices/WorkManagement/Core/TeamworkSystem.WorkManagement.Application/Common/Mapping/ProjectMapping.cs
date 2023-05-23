using AutoMapper;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Application.Features.Projects.Commands.CreateProject;
using TeamworkSystem.WorkManagement.Application.Features.Projects.Commands.UpdateProject;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Common.Mapping;

public class ProjectMapping : Profile
{
    public ProjectMapping()
    {
        CreateMap<CreateProjectCommand, Project>();
        CreateMap<UpdateProjectCommand, Project>();
        CreateMap<Project, ProjectResponse>();
    }
}
