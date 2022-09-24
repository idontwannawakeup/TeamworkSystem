using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data.Seeders;

namespace TeamworkSystem.WorkManagement.Persistence.Data.Seeders;

public class TeamsMembersSeeder : ITeamsMembersSeeder
{
    private static readonly object[] TeamsMembers =
    {
        new { TeamsId = Guid.Parse("73d936ae-0269-475d-b58f-8b456fafce85"), MembersId = Guid.Parse("61dfb9e3-1c27-424a-9963-9586ca110220") },
        new { TeamsId = Guid.Parse("80e2fd08-759c-42fa-a25b-ae8252d13ca6"), MembersId = Guid.Parse("0a906f06-fc52-417b-bc81-352df8bbe721") },
        new { TeamsId = Guid.Parse("12b4ec07-1d5f-4baf-9237-a3b19a5b7a68"), MembersId = Guid.Parse("61dfb9e3-1c27-424a-9963-9586ca110220") },
        new { TeamsId = Guid.Parse("79d2e324-7cae-4cb5-b039-27d2c07ce517"), MembersId = Guid.Parse("0a906f06-fc52-417b-bc81-352df8bbe721") },
        new { TeamsId = Guid.Parse("5b78adfd-017f-4b97-b7a3-06dc54813dc2"), MembersId = Guid.Parse("3f036c83-88e8-4aeb-ad33-290d60cf6b66") },
        new { TeamsId = Guid.Parse("29c1751d-6a4b-405d-9268-0863a4b0e196"), MembersId = Guid.Parse("7ad5c481-f391-45bb-a79c-cfcb1adb448b") },
        new { TeamsId = Guid.Parse("7ade466f-f4b1-4bc9-8e41-6fac1a1b8b01"), MembersId = Guid.Parse("3b333929-f974-444e-a8d3-68f50a0459c0") },
        new { TeamsId = Guid.Parse("d08c11eb-ecf6-47b6-9276-bbc46275f919"), MembersId = Guid.Parse("3b333929-f974-444e-a8d3-68f50a0459c0") },
        new { TeamsId = Guid.Parse("1ee4f75c-099d-4de3-a298-7d5ed17556f9"), MembersId = Guid.Parse("61dfb9e3-1c27-424a-9963-9586ca110220") },
        new { TeamsId = Guid.Parse("1ee4f75c-099d-4de3-a298-7d5ed17556f9"), MembersId = Guid.Parse("7ad5c481-f391-45bb-a79c-cfcb1adb448b") },
        new { TeamsId = Guid.Parse("1ee4f75c-099d-4de3-a298-7d5ed17556f9"), MembersId = Guid.Parse("0a906f06-fc52-417b-bc81-352df8bbe721") }
    };

    public void Seed(EntityTypeBuilder builder) => builder.HasData(TeamsMembers);
}
