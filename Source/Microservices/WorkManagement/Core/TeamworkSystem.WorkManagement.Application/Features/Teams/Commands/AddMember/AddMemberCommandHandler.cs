using MediatR;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.AddMember;

public class AddMemberCommandHandler : IRequestHandler<AddMemberCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AddMemberCommand request, CancellationToken cancellationToken)
    {
        var member = new UserProfile { Id = request.UserId };
        await _unitOfWork.TeamsRepository.AddMemberAsync(request.TeamId, member);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
