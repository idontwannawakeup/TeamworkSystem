using AutoMapper;
using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Features.Projects.Queries.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProjectByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProjectResponse> Handle(
        GetProjectByIdQuery request,
        CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectsRepository.GetCompleteEntityAsync(request.Id);
        return _mapper.Map<Project, ProjectResponse>(project);
    }
}
