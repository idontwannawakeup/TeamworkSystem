using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data.Seeders;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Persistence.Data.Seeders;

public class ProjectSeeder : IProjectSeeder
{
    private static readonly List<Project> Projects = new()
    {
        new Project
        {
            Id = Guid.Parse("2f73e5de-7fb3-47c1-9756-ea8a499d8eac"),
            TeamId = Guid.Parse("1ee4f75c-099d-4de3-a298-7d5ed17556f9"),
            Title = "Blog",
            Type = "Website",
            Description = "Just a simple blog from small team"
        }
    };

    public void Seed(EntityTypeBuilder<Project> builder) => builder.HasData(Projects);
}
