using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using TeamworkSystem.DataAccessLayer;
using TeamworkSystem.DataAccessLayer.Data.Repositories;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

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

        var filter = new Mock<IFilter<Project>>();
        filter.Setup(f => f.ApplyFilters(It.IsAny<IQueryable<Project>>()))
              .Returns<IQueryable<Project>>(projects => projects);

        _filterFactory.Setup(filterFactory => filterFactory.Get(It.IsAny<ProjectsParameters>()))
                      .Returns(filter.Object);

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
                PasswordHash =
                    "AQAAAAEAACcQAAAAEHIJxNS71yM2C19K8pJktzIg+gOfmz3ySn59bRPhmSrkabIMpXGGzKjZjhnEjFKqSA==",
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

    [TearDown]
    public async Task Finish()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.DisposeAsync();
    }

    [TestCase]
    public async Task GetAsync_WhenCalled_ReturnsProjects()
    {
        IEnumerable<Project> expected = new List<Project>
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
        };

        var actual = await _repository.GetAsync();

        foreach (var (expectedProject, actualProject) in expected.OrderBy(e => e.Id)
                                                                 .Zip(actual.OrderBy(a => a.Id)))
        {
            actualProject.Id.Should().Be(expectedProject.Id);
        }
    }

    [TestCase]
    public async Task GetAsync_WithDefaultParameters_ReturnsPagedProjects()
    {
        var parameters = new ProjectsParameters();
        IEnumerable<Project> expected = new List<Project>
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
        };

        var actual = await _repository.GetAsync(parameters);

        Assert.AreEqual(expected.Count(), actual.TotalEntitiesCount);
        Assert.AreEqual(parameters.PageNumber, actual.CurrentPage);
        Assert.AreEqual(parameters.PageSize, actual.PageSize);
        foreach (var (expectedProject, actualProject) in expected.OrderBy(e => e.Id)
                                                                 .Zip(actual.OrderBy(a => a.Id)))
        {
            actualProject.Id.Should().Be(expectedProject.Id);
        }
    }

    [TestCase]
    public async Task GetByIdAsync_WhenValidIdPassed_ShouldReturnProject()
    {
        var expected = new Project
        {
            Id = 1,
            TeamId = 9,
            Title = "Blog",
            Type = "Website",
            Description = "Just a simple blog from small team"
        };

        var actual = await _repository.GetByIdAsync(expected.Id);

        actual.Id.Should().Be(expected.Id);
    }

    [TestCase]
    public void GetByIdAsync_WhenIdOfNonExistingProjectPassed_ShouldThrowNotFound()
    {
        const int id = 10000;

        Func<Task<Project>> unitAction = async () => await _repository.GetByIdAsync(id);

        unitAction.Should().ThrowAsync<EntityNotFoundException>();
    }

    [TestCase]
    public async Task GetCompleteEntityAsync_WhenValidIdPassed_ShouldReturnProject()
    {
        var expected = new Project
        {
            Id = 1,
            TeamId = 9,
            Title = "Blog",
            Type = "Website",
            Description = "Just a simple blog from small team"
        };

        var actual = await _repository.GetCompleteEntityAsync(expected.Id);

        actual.Id.Should().Be(expected.Id);
    }

    [TestCase]
    public void GetCompleteEntityAsync_WhenIdOfNonExistingProjectPassed_ShouldThrowNotFound()
    {
        const int id = 10000;

        Func<Task<Project>> unitAction = async () => await _repository.GetCompleteEntityAsync(id);

        unitAction.Should().ThrowAsync<EntityNotFoundException>();
    }

    [TestCase]
    public async Task GetRelatedTeamAsync_WhenValidIdPassed_ShouldReturnTeamRelatedToProject()
    {
        const int projectId = 1;
        var expected = new Team
        {
            Id = 9,
            Name = "Thunder",
            Specialization = "Writing bugs",
            About = "We are writing bugs, fear us"
        };

        var actual = await _repository.GetRelatedTeamAsync(projectId);

        actual.Id.Should().Be(expected.Id);
    }

    [TestCase]
    public void GetRelatedTeamAsync_WhenIdOfNonExistingProjectPassed_ShouldThrowNotFound()
    {
        const int id = 10000;

        Func<Task<Team>> unitAction = async () => await _repository.GetRelatedTeamAsync(id);

        unitAction.Should().ThrowAsync<EntityNotFoundException>();
    }

    [TestCase]
    public async Task InsertAsync_WhenValidProjectInserted_ShouldBeCompletedSuccessfully()
    {
        var expectedCount = _context.Projects.Count() + 1;
        var project = new Project
        {
            TeamId = 9,
            Title = "Another one",
            Type = "Website",
            Description = "Just a simple project for unit test"
        };

        await _repository.InsertAsync(project);
        await _context.SaveChangesAsync();
        var actualCount = _context.Projects.Count();

        actualCount.Should().Be(expectedCount);
    }

    [TestCase]
    public async Task UpdateAsync_WhenValidProjectUpdated_ShouldBeCompletedSuccessfully()
    {
        var expected = new Project
        {
            Id = 1,
            TeamId = 9,
            Title = "Not a Blog anymore",
            Type = "Website",
            Description = "Just a simple blog from small team"
        };

        var project = await _repository.GetByIdAsync(expected.Id);
        project.Title = expected.Title;
        await _repository.UpdateAsync(project);
        await _context.SaveChangesAsync();
        var actual = await _repository.GetByIdAsync(expected.Id);

        expected.Id.Should().Be(actual.Id);
        expected.Title.Should().Be(actual.Title);
    }

    [TestCase(1)]
    [TestCase(2)]
    public async Task DeleteAsync_WhenExistingProjectIdPassed_ShouldDeleteProject(int projectId)
    {
        var expectedCount = _context.Projects.Count() - 1;

        await _repository.DeleteAsync(projectId);
        await _context.SaveChangesAsync();
        var actualCount = _context.Projects.Count();

        actualCount.Should().Be(expectedCount);
    }

    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    public void DeleteAsync_WhenNonExistingProjectIdPassed_ShouldThrowNotFound(int projectId)
    {
        Func<Task> unitAction = async () => await _repository.DeleteAsync(projectId);

        unitAction.Should().ThrowAsync<EntityNotFoundException>();
    }
}
