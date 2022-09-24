using MediatR;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data;

namespace TeamworkSystem.WorkManagement.Application.Features.Projects.Commands.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(
        DeleteProjectCommand request,
        CancellationToken cancellationToken)
    {
        await _unitOfWork.ProjectsRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
