using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Seeders;

namespace TeamworkSystem.DataAccessLayer.Seeders;

public class TeamSeeder : ITeamSeeder
{
    private static readonly Team[] Teams =
    {
        new()
        {
            Id = 1,
            Name = "Amigos",
            LeaderId = "61dfb9e3-1c27-424a-9963-9586ca110220",
            Specialization = "Web Development",
            About = "Young and ambitious"
        },
        new()
        {
            Id = 2,
            Name = "Heatwave",
            LeaderId = "0a906f06-fc52-417b-bc81-352df8bbe721",
            Specialization = "OblEnergo",
            About = null
        },
        new()
        {
            Id = 3,
            Name = "Lazy Guys",
            LeaderId = "61dfb9e3-1c27-424a-9963-9586ca110220",
            Specialization = "Design",
            About = "Lazy guys"
        },
        new()
        {
            Id = 4,
            Name = "Champions",
            LeaderId = "0a906f06-fc52-417b-bc81-352df8bbe721",
            Specialization = null,
            About = null
        },
        new()
        {
            Id = 5,
            Name = "Legends",
            LeaderId = "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
            Specialization = null,
            About = null
        },
        new()
        {
            Id = 6,
            Name = "Shakedown",
            LeaderId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
            Specialization = null,
            About = null
        },
        new()
        {
            Id = 7,
            Name = "Warriors",
            LeaderId = "3b333929-f974-444e-a8d3-68f50a0459c0",
            Specialization = null,
            About = "We are the warriors"
        },
        new()
        {
            Id = 8,
            Name = "Defenders",
            LeaderId = "3b333929-f974-444e-a8d3-68f50a0459c0",
            Specialization = "Tests",
            About = "We are the defenders"
        },
        new()
        {
            Id = 9,
            Name = "Thunder",
            LeaderId = "61dfb9e3-1c27-424a-9963-9586ca110220",
            Specialization = "Writing bugs",
            About = "We are writing bugs, fear us"
        }
    };

    public void Seed(EntityTypeBuilder<Team> builder) => builder.HasData(Teams);
}
