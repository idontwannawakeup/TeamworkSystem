namespace TeamworkSystem.Content.Domain.Entities;

public class UserProfile
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Profession { get; set; }
    public string? Specialization { get; set; }
    public string? Avatar { get; set; }

    public List<Notification> Notifications { get; set; } = default!;
    public List<RecentProject> RecentProjects { get; set; } = default!;
    public List<RecentTeam> RecentTeams { get; set; } = default!;
    public List<RecentTicket> RecentTickets { get; set; } = default!;
}
