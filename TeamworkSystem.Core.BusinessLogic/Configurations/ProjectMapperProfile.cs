using AutoMapper;
using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.WorkManagement.DataAccess.Entities;

namespace TeamworkSystem.Core.BusinessLogic.Configurations;

public class ProjectMapperProfile : Profile
{
    public ProjectMapperProfile()
    {
        CreateMap<ProjectRequest, Project>();
        CreateMap<Project, ProjectResponse>();
    }
}
