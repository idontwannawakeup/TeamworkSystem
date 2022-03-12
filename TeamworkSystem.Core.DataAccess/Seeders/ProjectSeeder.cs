using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Interfaces.Seeders;

namespace TeamworkSystem.Core.DataAccess.Seeders;

public class ProjectSeeder : IProjectSeeder
{
    private static readonly List<Project> Projects = new()
    {
        new Project
        {
            Id = 1,
            TeamId = 9,
            Title = "Blog",
            Type = "Website",
            Description = "Just a simple blog from small team"
        }
    };

    public void Seed(EntityTypeBuilder<Project> builder) => builder.HasData(Projects);
}
