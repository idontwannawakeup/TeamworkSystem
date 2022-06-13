namespace TeamworkSystem.Content.Domain.Entities;

public class UserProfile
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Profession { get; set; }
    public string? Specialization { get; set; }
    public string? Avatar { get; set; }
}
