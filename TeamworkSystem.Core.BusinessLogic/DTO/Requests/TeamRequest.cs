namespace TeamworkSystem.Core.BusinessLogic.DTO.Requests;

public class TeamRequest
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;
    public string? LeaderId { get; set; }
    public string? Specialization { get; set; }
    public string? About { get; set; }
}
