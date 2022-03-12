namespace TeamworkSystem.Core.BusinessLogic.DTO.Requests;

public class ProjectRequest
{
    public int Id { get; set; }
    public int TeamId { get; set; }

    public string Title { get; set; } = default!;
    public string? Type { get; set; }
    public string? Url { get; set; }

    public string? Description { get; set; }
}
