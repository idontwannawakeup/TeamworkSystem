using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.BusinessLogicLayer.DTO.Requests
{
    public class UserAvatarRequest
    {
        public string UserId { get; set; } = default!;

        public IFormFile Avatar { get; set; } = default!;
    }
}
