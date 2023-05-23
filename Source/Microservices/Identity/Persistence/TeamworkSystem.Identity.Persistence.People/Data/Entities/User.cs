using Microsoft.AspNetCore.Identity;

namespace TeamworkSystem.Identity.Persistence.People.Data.Entities;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Profession { get; set; }
    public string? Specialization { get; set; }
    public string? Avatar { get; set; }
}
