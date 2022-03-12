namespace TeamworkSystem.Core.DataAccess.Entities;

public class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;
    public string? LeaderId { get; set; }
    public string? Specialization { get; set; }
    public string? About { get; set; }
    public string? Avatar { get; set; }

    public UserProfile? Leader { get; set; }
    public List<Project> Projects { get; set; } = default!;
    public List<UserProfile> Members { get; set; } = default!;
}
