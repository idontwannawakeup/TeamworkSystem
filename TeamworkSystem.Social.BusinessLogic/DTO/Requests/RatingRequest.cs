namespace TeamworkSystem.Social.BusinessLogic.DTO.Requests;

public class RatingRequest
{
    public int Id { get; set; }
    public string FromId { get; set; } = default!;
    public string ToId { get; set; } = default!;

    public int Social { get; set; }
    public int Skills { get; set; }
    public int Responsibility { get; set; }
    public int Punctuality { get; set; }
    public string? Comment { get; set; } = default!;
}
