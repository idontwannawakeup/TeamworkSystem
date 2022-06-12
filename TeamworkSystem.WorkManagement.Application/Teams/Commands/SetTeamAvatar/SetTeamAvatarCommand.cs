using MediatR;
using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.WorkManagement.Application.Teams.Commands.SetTeamAvatar;

public class SetTeamAvatarCommand : IRequest
{
    public Guid TeamId { get; set; }
    public IFormFile Avatar { get; set; } = default!;
}
