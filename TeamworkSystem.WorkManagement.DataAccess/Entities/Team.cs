namespace TeamworkSystem.WorkManagement.DataAccess.Entities;

public class Team
{
    public Guid Id { get; set; }
    public Guid? LeaderId { get; set; }

    public string Name { get; set; } = default!;
    public string? Specialization { get; set; }
    public string? About { get; set; }
    public string? Avatar { get; set; }

    public UserProfile? Leader { get; set; }
    public List<Project> Projects { get; set; } = default!;
    public List<UserProfile> Members { get; set; } = default!;
}
