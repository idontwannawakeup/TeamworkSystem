namespace TeamworkSystem.Core.BusinessLogic.DTO.Requests;

public class TeamMemberRequest
{
    public string UserId { get; set; } = default!;
    public int TeamId { get; set; }
}
