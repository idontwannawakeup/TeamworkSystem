using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Core.DataAccess.Interfaces.Seeders;

namespace TeamworkSystem.Core.DataAccess.Seeders;

public class TeamsMembersSeeder : ITeamsMembersSeeder
{
    private static readonly object[] TeamsMembers =
    {
        new { TeamsId = 1, MembersId = "61dfb9e3-1c27-424a-9963-9586ca110220" },
        new { TeamsId = 2, MembersId = "0a906f06-fc52-417b-bc81-352df8bbe721" },
        new { TeamsId = 3, MembersId = "61dfb9e3-1c27-424a-9963-9586ca110220" },
        new { TeamsId = 4, MembersId = "0a906f06-fc52-417b-bc81-352df8bbe721" },
        new { TeamsId = 5, MembersId = "3f036c83-88e8-4aeb-ad33-290d60cf6b66" },
        new { TeamsId = 6, MembersId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b" },
        new { TeamsId = 7, MembersId = "3b333929-f974-444e-a8d3-68f50a0459c0" },
        new { TeamsId = 8, MembersId = "3b333929-f974-444e-a8d3-68f50a0459c0" },
        new { TeamsId = 9, MembersId = "61dfb9e3-1c27-424a-9963-9586ca110220" },
        new { TeamsId = 9, MembersId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b" },
        new { TeamsId = 9, MembersId = "0a906f06-fc52-417b-bc81-352df8bbe721" }
    };

    public void Seed(EntityTypeBuilder builder) => builder.HasData(TeamsMembers);
}
