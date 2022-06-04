using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using TeamworkSystem.DataAccessLayer;
using TeamworkSystem.DataAccessLayer.Data.Repositories;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;

namespace TeamworkSystem.Tests.Repositories;

public class ProjectsRepositoryTests
{
    private ProjectsRepository _repository = default!;

    private TeamworkSystemContext _context = default!;
    private Mock<IFilterFactory<Project>> _filterFactory = default!;

    [SetUp]
    public async Task Initialize()
    {
        var optionsBuilder = new DbContextOptionsBuilder<TeamworkSystemContext>()
                             .UseInMemoryDatabase("TeamworkSystemInMemoryDb")
                             .EnableSensitiveDataLogging()
                             .EnableDetailedErrors();

        _context = new TeamworkSystemContext(optionsBuilder.Options);
        _filterFactory = new Mock<IFilterFactory<Project>>();
        _repository = new ProjectsRepository(_context, _filterFactory.Object);

        await _context.AddRangeAsync(new List<User>
        {
            new User
            {
                Id = "61dfb9e3-1c27-424a-9963-9586ca110220",
                UserName = "User1",
                NormalizedUserName = "USER1",
                Email = "user1@gmail.com",
                NormalizedEmail = "USER1@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEHIJxNS71yM2C19K8pJktzIg+gOfmz3ySn59bRPhmSrkabIMpXGGzKjZjhnEjFKqSA==",
                ConcurrencyStamp = "f44736ce-d7d2-41f5-89f7-95919ba4b4fa",
                SecurityStamp = "c58ae9db-4ab1-41d9-acbf-dbd162586983",
                FirstName = "Ostap",
                LastName = "Nice",
                Profession = "Developer",
                Specialization = "Backend"
            },
        });

        await _context.Teams.AddRangeAsync(new List<Team>
        {
            new Team
            {
                Id = 9,
                Name = "Thunder",
                Specialization = "Writing bugs",
                About = "We are writing bugs, fear us"
            }
        });

        await _context.Projects.AddRangeAsync(new List<Project>
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
                TeamId = 9,
                Title = "ABlog",
                Type = "Website",
                Description = "And another one"
            }
        });

        await _context.SaveChangesAsync();
    }
}
