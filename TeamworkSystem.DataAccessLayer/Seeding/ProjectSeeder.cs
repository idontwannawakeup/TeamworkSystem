using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Seeding
{
    public class ProjectSeeder : ISeeder<Project>
    {
        private static readonly List<Project> projects = new()
        {
            new Project
            {
                Id = 1,
                TeamId = 9,
                Title = "Blog",
                Type = "Website",
                Description = "Just a simple blog from small team"
            },
            new Project
            {
                Id = 2, TeamId = 1, Title = "Project A", Type = "Web Application",
                Url = "https://projecta.com",
                Description = "A web application for managing projects"
            },
            new Project
            {
                Id = 3, TeamId = 1, Title = "Project B", Type = "Mobile Application",
                Url = "https://projectb.com",
                Description = "A mobile application for tracking tasks"
            },
            new Project
            {
                Id = 4, TeamId = 2, Title = "Project C", Type = "Desktop Application",
                Url = "https://projectc.com",
                Description = "A desktop application for managing finances"
            },
            new Project
            {
                Id = 5, TeamId = 2, Title = "Project D", Type = "Web Application",
                Url = "https://projectd.com",
                Description = "A web application for managing projects"
            },
            new Project
            {
                Id = 6, TeamId = 3, Title = "Project E", Type = "Mobile Application",
                Url = "https://projecte.com",
                Description = "A mobile application for tracking tasks"
            },
            new Project
            {
                Id = 7, TeamId = 3, Title = "Project F", Type = "Desktop Application",
                Url = "https://projectf.com",
                Description = "A desktop application for managing finances"
            },
        };

        public void Seed(EntityTypeBuilder<Project> builder) => builder.HasData(projects);
    }
}
