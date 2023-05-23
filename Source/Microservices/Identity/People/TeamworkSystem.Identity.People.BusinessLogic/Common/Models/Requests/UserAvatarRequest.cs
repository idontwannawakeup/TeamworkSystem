using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.Identity.People.BusinessLogic.Common.Models.Requests;

public class UserAvatarRequest
{
    public Guid UserId { get; set; } = default!;

    public IFormFile Avatar { get; set; } = default!;
}
