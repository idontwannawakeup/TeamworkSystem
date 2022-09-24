namespace TeamworkSystem.Social.BusinessLogic.DTO.Responses;

public class RatingResponse
{
    public Guid Id { get; set; }
    public Guid FromId { get; set; }
    public Guid ToId { get; set; }

    public int Social { get; set; }
    public int Skills { get; set; }
    public int Responsibility { get; set; }
    public int Punctuality { get; set; }
    public double Average { get; set; }
    public string? Comment { get; set; }

    public UserResponse From { get; set; } = default!;
    public UserResponse To { get; set; } = default!;
}
