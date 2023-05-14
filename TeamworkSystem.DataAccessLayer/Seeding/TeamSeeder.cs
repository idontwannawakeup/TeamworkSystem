using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Seeding
{
    public class TeamSeeder : ISeeder<Team>
    {
        private static readonly List<Team> teams = new()
        {
            new Team
            {
                Id = 1,
                Name = "Amigos",
                LeaderId = "013a2014-4a25-4a3d-9fae-e0f783d42ef9",
                Specialization = "Web Development",
                About = "Young and ambitious"
            },
            new Team
            {
                Id = 2,
                Name = "Heatwave",
                LeaderId = "0a906f06-fc52-417b-bc81-352df8bbe721",
                Specialization = "OblEnergo",
                About = null
            },
            new Team
            {
                Id = 3,
                Name = "Lazy Guys",
                LeaderId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                Specialization = "Design",
                About = "Lazy guys"
            },
            new Team
            {
                Id = 4,
                Name = "Champions",
                LeaderId = "0a906f06-fc52-417b-bc81-352df8bbe721",
                Specialization = null,
                About = null
            },
            new Team
            {
                Id = 5,
                Name = "Legends",
                LeaderId = "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                Specialization = null,
                About = null
            },
            new Team
            {
                Id = 6,
                Name = "Shakedown",
                LeaderId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                Specialization = null,
                About = null
            },
            new Team
            {
                Id = 7,
                Name = "Warriors",
                LeaderId = "3b333929-f974-444e-a8d3-68f50a0459c0",
                Specialization = null,
                About = "We are the warriors"
            },
            new Team
            {
                Id = 8,
                Name = "Defenders",
                LeaderId = "3b333929-f974-444e-a8d3-68f50a0459c0",
                Specialization = "Tests",
                About = "We are the defenders"
            },
            new Team
            {
                Id = 9,
                Name = "Thunder",
                LeaderId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                Specialization = "Writing bugs",
                About = "We are writing bugs, fear us"
            },
            new Team
            {
                Id = 10,
                Name = "Gale",
                LeaderId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                Specialization = "Cloud Computing",
                About = "We offer reliable, secure data storage and processing services over the internet"
            },
            new Team
            {
                Id = 11,
                Name = "Lightning",
                LeaderId = "3b333929-f974-444e-a8d3-68f50a0459c0",
                Specialization = "Testing",
                About = "We ensure all software runs smoothly and efficiently"
            },
            new Team
            {
                Id = 12,
                Name = "Blizzard",
                LeaderId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                Specialization = "UI/UX Design",
                About = "We create intuitive and aesthetic user interfaces"
            },
            new Team
            {
                Id = 13,
                Name = "Hurricane",
                LeaderId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                Specialization = "Backend Development",
                About = "We build robust and scalable server-side applications"
            },
            new Team
            {
                Id = 14,
                Name = "Cyclone",
                LeaderId = "3b333929-f974-444e-a8d3-68f50a0459c0",
                Specialization = "Frontend Development",
                About = "We create interactive and responsive web pages"
            },
            new Team
            {
                Id = 15,
                Name = "Tornado",
                LeaderId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                Specialization = "Data Analysis",
                About = "We extract insights and patterns from complex data"
            },
            new Team
            {
                Id = 16,
                Name = "Tempest",
                LeaderId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                Specialization = "Database Management",
                About = "We manage and organize complex databases efficiently"
            },
            new Team
            {
                Id = 17,
                Name = "Whirlwind",
                LeaderId = "3b333929-f974-444e-a8d3-68f50a0459c0",
                Specialization = "Machine Learning",
                About = "We develop algorithms that can learn from and make decisions or predictions"
            },
            new Team
            {
                Id = 18,
                Name = "Typhoon",
                LeaderId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                Specialization = "Cybersecurity",
                About = "We protect computer systems from theft or damage to their hardware, software, or data"
            },
        };

        public void Seed(EntityTypeBuilder<Team> builder) => builder.HasData(teams);
    }
}
