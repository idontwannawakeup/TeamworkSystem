using AutoMapper;
using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Features.Projects.Queries.GetTeamProjects;

public class GetTeamProjectsQueryHandler : IRequestHandler<GetTeamProjectsQuery, IEnumerable<ProjectResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTeamProjectsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectResponse>> Handle(
        GetTeamProjectsQuery request,
        CancellationToken cancellationToken)
    {
        var team = await _unitOfWork.TeamsRepository.GetCompleteEntityAsync(request.TeamId);
        var projects = team.Projects;
        return projects.Select(_mapper.Map<Project, ProjectResponse>);
    }
}
