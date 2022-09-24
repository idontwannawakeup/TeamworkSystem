using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.Identity.BusinessLogic.DTO.Requests;

public class UserAvatarRequest
{
    public Guid UserId { get; set; } = default!;

    public IFormFile Avatar { get; set; } = default!;
}
