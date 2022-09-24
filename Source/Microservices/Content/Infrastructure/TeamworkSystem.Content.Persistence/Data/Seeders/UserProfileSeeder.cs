using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Persistence.Data.Seeders;

public class UserProfileSeeder
{
    // For all seeded users password is "User%password{number}"
    // where number is number from UserName
    private static readonly List<UserProfile> Users = new()
    {
        new UserProfile
        {
            Id = Guid.Parse("61dfb9e3-1c27-424a-9963-9586ca110220"),
            FirstName = "Ostap",
            LastName = "Nice",
            Profession = "Developer",
            Specialization = "Backend"
        },
        new UserProfile
        {
            Id = Guid.Parse("3b333929-f974-444e-a8d3-68f50a0459c0"),
            FirstName = "Esmaralda",
            LastName = "Voigt",
            Profession = "Developer",
            Specialization = "Frontend"
        },
        new UserProfile
        {
            Id = Guid.Parse("a36b02e1-81a9-47f4-89b6-d33c4f40ed5f"),
            FirstName = "Sophia",
            LastName = "Beringer",
            Profession = null,
            Specialization = "Fullstack"
        },
        new UserProfile
        {
            Id = Guid.Parse("013a2014-4a25-4a3d-9fae-e0f783d42ef9"),
            FirstName = "Marlyn",
            LastName = "Hendry",
            Profession = "Artist",
            Specialization = null
        },
        new UserProfile
        {
            Id = Guid.Parse("ae557ffc-2906-4913-bd26-40aa98a55570"),
            FirstName = "Vlasi",
            LastName = "Arterberry",
            Profession = "Designer",
            Specialization = "Interier"
        },
        new UserProfile
        {
            Id = Guid.Parse("e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2"),
            FirstName = "Chasity",
            LastName = "Ilbert",
            Profession = null,
            Specialization = null
        },
        new UserProfile
        {
            Id = Guid.Parse("bc0c5522-0a02-4f23-bb6a-319529716a94"),
            FirstName = "Seraphina",
            LastName = "Salmon",
            Profession = "Developer",
            Specialization = "Backend"
        },
        new UserProfile
        {
            Id = Guid.Parse("7484e532-dc8e-4005-8b67-15ad8a421a37"),
            FirstName = "Chas",
            LastName = "Hope",
            Profession = "Designer",
            Specialization = null
        },
        new UserProfile
        {
            Id = Guid.Parse("3f036c83-88e8-4aeb-ad33-290d60cf6b66"),
            FirstName = "Nadezhda",
            LastName = "Haynes",
            Profession = null,
            Specialization = null
        },
        new UserProfile
        {
            Id = Guid.Parse("7ad5c481-f391-45bb-a79c-cfcb1adb448b"),
            FirstName = "Sonny",
            LastName = "Gibb",
            Profession = "Tester",
            Specialization = null
        },
        new UserProfile
        {
            Id = Guid.Parse("0a906f06-fc52-417b-bc81-352df8bbe721"),
            FirstName = "Eric",
            LastName = "Lincoln",
            Profession = "Designer",
            Specialization = null
        }
    };

    public void Seed(EntityTypeBuilder<UserProfile> builder) => builder.HasData(Users);
}
