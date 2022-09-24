namespace TeamworkSystem.Social.BusinessLogic.Common.Models.Requests;

public class RatingRequest
{
    public Guid Id { get; set; }
    public Guid FromId { get; set; } = default!;
    public Guid ToId { get; set; } = default!;

    public int Social { get; set; }
    public int Skills { get; set; }
    public int Responsibility { get; set; }
    public int Punctuality { get; set; }
    public string? Comment { get; set; } = default!;
}
