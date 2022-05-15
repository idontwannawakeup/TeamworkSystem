using AutoMapper;
using MediatR;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Responses;
using TeamworkSystem.WorkManagement.Application.Interfaces;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Projects.Queries.GetProjects;

public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, PagedList<ProjectResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProjectsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<ProjectResponse>> Handle(
        GetProjectsQuery request,
        CancellationToken cancellationToken)
    {
        var projects = await _unitOfWork.ProjectsRepository.GetAsync(request.Parameters);
        return projects.Map(_mapper.Map<Project, ProjectResponse>);
    }
}
