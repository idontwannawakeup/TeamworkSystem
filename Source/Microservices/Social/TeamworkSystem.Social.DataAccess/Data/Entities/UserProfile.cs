namespace TeamworkSystem.Social.DataAccess.Data.Entities;

public class UserProfile
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Profession { get; set; }
    public string? Specialization { get; set; }
    public string? Avatar { get; set; }

    public List<Rating> MyRatings { get; set; } = default!;
    public List<Rating> RatingsFromMe { get; set; } = default!;
    public List<UserProfile> Friends { get; set; } = default!;
    public List<UserProfile> FriendForUsers { get; set; } = default!;
}
