namespace TeamworkSystem.Core.BusinessLogic.DTO.Requests;

public class TeamRequest
{
    public Guid Id { get; set; }
    public Guid LeaderId { get; set; }

    public string Name { get; set; } = default!;
    public string? Specialization { get; set; }
    public string? About { get; set; }
}
