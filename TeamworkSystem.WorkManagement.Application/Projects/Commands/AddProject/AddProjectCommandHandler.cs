using AutoMapper;
using MediatR;
using TeamworkSystem.WorkManagement.Application.Interfaces;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Projects.Commands.AddProject;

public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _mapper.Map<AddProjectCommand, Project>(request);
        await _unitOfWork.ProjectsRepository.InsertAsync(project);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
