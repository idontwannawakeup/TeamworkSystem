using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.Core.BusinessLogic.DTO.Requests;

public class TeamAvatarRequest
{
    public Guid TeamId { get; set; }

    public IFormFile Avatar { get; set; } = default!;
}
