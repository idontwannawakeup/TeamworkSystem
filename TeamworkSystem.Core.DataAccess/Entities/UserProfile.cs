namespace TeamworkSystem.Core.DataAccess.Entities;

public class UserProfile
{
    public Guid Id { get; set; } = default!;

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Profession { get; set; }
    public string? Specialization { get; set; }
    public string? Avatar { get; set; }

    public List<Team> Teams { get; set; } = default!;
    public List<Ticket> Tickets { get; set; } = default!;
}
