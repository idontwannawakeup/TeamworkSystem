using AutoMapper;
using MediatR;
using TeamworkSystem.WorkManagement.Application.Interfaces;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _mapper.Map<CreateProjectCommand, Project>(request);
        await _unitOfWork.ProjectsRepository.InsertAsync(project);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
