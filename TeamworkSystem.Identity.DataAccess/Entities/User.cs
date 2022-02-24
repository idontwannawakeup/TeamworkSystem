using Microsoft.AspNetCore.Identity;

namespace TeamworkSystem.Identity.DataAccess.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Profession { get; set; }
    public string? Specialization { get; set; }
    public string? Avatar { get; set; }

    public List<User> Friends { get; set; } = default!;
    public List<User> FriendForUsers { get; set; } = default!;
}
