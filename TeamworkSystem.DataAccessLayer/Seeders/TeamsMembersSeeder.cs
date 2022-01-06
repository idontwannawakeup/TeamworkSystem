using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Interfaces.Seeders;

namespace TeamworkSystem.DataAccessLayer.Seeders;

public class TeamsMembersSeeder : ITeamsMembersSeeder
{
    private static readonly object[] TeamsMembers =
    {
        new { TeamId = 1, UserId = "61dfb9e3-1c27-424a-9963-9586ca110220" },
        new { TeamId = 2, UserId = "0a906f06-fc52-417b-bc81-352df8bbe721" },
        new { TeamId = 3, UserId = "61dfb9e3-1c27-424a-9963-9586ca110220" },
        new { TeamId = 4, UserId = "0a906f06-fc52-417b-bc81-352df8bbe721" },
        new { TeamId = 5, UserId = "3f036c83-88e8-4aeb-ad33-290d60cf6b66" },
        new { TeamId = 6, UserId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b" },
        new { TeamId = 7, UserId = "3b333929-f974-444e-a8d3-68f50a0459c0" },
        new { TeamId = 8, UserId = "3b333929-f974-444e-a8d3-68f50a0459c0" },
        new { TeamId = 9, UserId = "61dfb9e3-1c27-424a-9963-9586ca110220" },
        new { TeamId = 9, UserId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b" },
        new { TeamId = 9, UserId = "0a906f06-fc52-417b-bc81-352df8bbe721" }
    };

    public void Seed(EntityTypeBuilder builder) => builder.HasData(TeamsMembers);
}
