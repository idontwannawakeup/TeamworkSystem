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
                Id = 2,
                TeamId = 1,
                Title = "Code A",
                Type = "Web Application",
                Url = "https://projecta.com",
                Description = "A web application for managing projects"
            },
            new Project
            {
                Id = 3,
                TeamId = 1,
                Title = "PartnerUp", 
                Type = "Mobile Application",
                Url = "https://projectb.com",
                Description = "A mobile application for tracking tasks"
            },
            new Project
            {
                Id = 4,
                TeamId = 2,
                Title = "Ivy C",
                Type = "Desktop Application",
                Url = "https://projectc.com",
                Description = "A desktop application for managing finances"
            },
            new Project
            {
                Id = 5,
                TeamId = 2,
                Title = "ProjectTracker D",
                Type = "Web Application",
                Url = "https://projectd.com",
                Description = "A web application for managing projects"
            },
            new Project
            {
                Id = 6,
                TeamId = 3,
                Title = "TaskTracker E",
                Type = "Mobile Application",
                Url = "https://projecte.com",
                Description = "A mobile application for tracking tasks"
            },
            new Project
            {
                Id = 7,
                TeamId = 3,
                Title = "FinanceTracker F",
                Type = "Desktop Application",
                Url = "https://projectf.com",
                Description = "A desktop application for managing finances"
            },
            new Project
            {
                Id = 8,
                TeamId = 3,
                Title = "TaskMaster Ultra",
                Type = "Desktop Application",
                Url = "https://projectf.com",
                Description = "A desktop application for managing finances"
            },
            new Project
            {
                Id = 9,
                TeamId = 2,
                Title = "TaskMaster Pro",
                Type = "Web Application",
                Url = "https://taskmasterpro.com",
                Description = "A web application for effective task management"
            },
            new Project
            {
                Id = 10,
                TeamId = 2,
                Title = "HealthTrack Mobile",
                Type = "Mobile Application",
                Url = "https://healthtrackmobile.com",
                Description = "A mobile application for comprehensive health tracking"
            },
            new Project
            {
                Id = 11,
                TeamId = 3,
                Title = "PhotoMagic Desktop",
                Type = "Desktop Application",
                Url = "https://photomagicdesktop.com",
                Description = "A desktop application for intuitive photo editing"
            },
            new Project
            {
                Id = 12,
                TeamId = 1,
                Title = "ProjectSphere",
                Type = "Web Application",
                Url = "https://projectsphere.com",
                Description = "A web application for streamlined project management"
            },
            new Project
            {
                Id = 13,
                TeamId = 4,
                Title = "Socialize Mobile",
                Type = "Mobile Application",
                Url = "https://socializemobile.com",
                Description = "A mobile application for next-gen social networking"
            },
            new Project
            {
                Id = 14,
                TeamId = 3,
                Title = "VideoWizard Desktop",
                Type = "Desktop Application",
                Url = "https://videowizarddesktop.com",
                Description = "A desktop application for professional video editing"
            },
            new Project
            {
                Id = 15,
                TeamId = 2,
                Title = "ClientConnect Web",
                Type = "Web Application",
                Url = "https://clientconnectweb.com",
                Description = "A web application for efficient customer relationship management"
            },
            new Project
            {
                Id = 16,
                TeamId = 1,
                Title = "FinTrack Mobile",
                Type = "Mobile Application",
                Url = "https://fintrackmobile.com",
                Description = "A mobile application for personal finance tracking"
            },
            new Project
            {
                Id = 17,
                TeamId = 4,
                Title = "MusicMaster Desktop",
                Type = "Desktop Application",
                Url = "https://musicmasterdesktop.com",
                Description = "A desktop application for simplified music production"
            },
            new Project
            {
                Id = 18,
                TeamId = 3,
                Title = "E-Shop Web",
                Type = "Web Application",
                Url = "https://eshopweb.com",
                Description = "A web application for seamless e-commerce experience"
            }
        };

        public void Seed(EntityTypeBuilder<Project> builder) => builder.HasData(projects);
    }
}
