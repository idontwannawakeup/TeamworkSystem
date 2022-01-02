using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.BusinessLogicLayer.DTO.Requests
{
    public class TeamAvatarRequest
    {
        public int TeamId { get; set; }

        public IFormFile Avatar { get; set; } = default!;
    }
}
