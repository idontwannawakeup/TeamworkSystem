using MediatR;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data.Storages;

namespace TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.SetTeamAvatar;

public class SetTeamAvatarCommandHandler : IRequestHandler<SetTeamAvatarCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPhotoStorage _photoStorage;

    public SetTeamAvatarCommandHandler(IUnitOfWork unitOfWork, IPhotoStorage photoStorage)
    {
        _unitOfWork = unitOfWork;
        _photoStorage = photoStorage;
    }

    public async Task<Unit> Handle(
        SetTeamAvatarCommand request,
        CancellationToken cancellationToken)
    {
        var team = await _unitOfWork.TeamsRepository.GetByIdAsync(request.TeamId);
        team.Avatar = await _photoStorage.SavePhotoAsync(request.Avatar);
        await _unitOfWork.TeamsRepository.UpdateAsync(team);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
