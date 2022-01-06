using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Seeding;

public class ProjectSeeder : ISeeder<Project>
{
    private static readonly List<Project> Projects = new()
    {
        new Project
        {
            Id = 1,
            TeamId = 9,
            Title = "Blog",
            Type = "Website",
            Description = "Just a simple blog from small team",
        },
    };

    public void Seed(EntityTypeBuilder<Project> builder) => builder.HasData(Projects);
}
