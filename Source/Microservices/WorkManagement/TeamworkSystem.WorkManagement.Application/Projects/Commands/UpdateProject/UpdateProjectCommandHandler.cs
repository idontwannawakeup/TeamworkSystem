using AutoMapper;
using MediatR;
using TeamworkSystem.WorkManagement.Application.Interfaces;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Projects.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(
        UpdateProjectCommand request,
        CancellationToken cancellationToken)
    {
        var project = _mapper.Map<UpdateProjectCommand, Project>(request);
        await _unitOfWork.ProjectsRepository.UpdateAsync(project);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
