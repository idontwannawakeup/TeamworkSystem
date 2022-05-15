using AutoMapper;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Requests;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Responses;
using TeamworkSystem.WorkManagement.DataAccess.Entities;

namespace TeamworkSystem.WorkManagement.BusinessLogic.Configurations;

public class ProjectMapperProfile : Profile
{
    public ProjectMapperProfile()
    {
        CreateMap<ProjectRequest, Project>();
        CreateMap<Project, ProjectResponse>();
    }
}
