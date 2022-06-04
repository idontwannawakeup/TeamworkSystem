using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.Tests.Services;

public class ProjectsServiceTests
{
    private ProjectsService _service = default!;
    private Mock<IUnitOfWork> _unitOfWork = default!;
    private Mock<IProjectsRepository> _projectsRepository = default!;
    private Mock<ITeamsRepository> _teamsRepository = default!;
    private Mock<IMapper> _mapper = default!;

    [SetUp]
    public void Initialize()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _projectsRepository = new Mock<IProjectsRepository>();
        _teamsRepository = new Mock<ITeamsRepository>();
        _mapper = new Mock<IMapper>();

        _unitOfWork.Setup(uof => uof.ProjectsRepository).Returns(_projectsRepository.Object);
        _unitOfWork.Setup(uof => uof.TeamsRepository).Returns(_teamsRepository.Object);
        _unitOfWork.Setup(uof => uof.SaveChangesAsync()).Returns(Task.CompletedTask);

        _mapper.Setup(m => m.Map<Project, ProjectResponse>(It.IsAny<Project>()))
               .Returns<Project>(project => new ProjectResponse
               {
                   Id = project.Id,
                   TeamId = project.TeamId,
                   Description = project.Description,
                   Title = project.Title,
                   Type = project.Type,
                   Url = project.Url,
               });

        _mapper.Setup(m => m.Map<ProjectRequest, Project>(It.IsAny<ProjectRequest>()))
               .Returns<ProjectRequest>(project => new Project
               {
                   Id = project.Id,
                   TeamId = project.TeamId,
                   Description = project.Description,
                   Title = project.Title,
                   Type = project.Type,
                   Url = project.Url
               });

        _service = new ProjectsService(_unitOfWork.Object, _mapper.Object);
    }

    [TestCase]
    public async Task GetAsync_WithDefaultParameters_ShouldReturnPagedProjects()
    {
        var project = new Project
        {
            Id = 1,
            TeamId = 9,
            Title = "Blog",
            Type = "Website",
            Description = "Just a simple blog from small team"
        };

        var projects = new List<Project> { project };
        const int expectedPageNumber = 1;
        const int expectedPageSize = 1;
        var parameters = new ProjectsParameters();

        _projectsRepository.Setup(repository => repository.GetAsync(It.IsAny<ProjectsParameters>()))
                           .ReturnsAsync(new PagedList<Project>(
                               projects,
                               projects.Count,
                               expectedPageNumber,
                               expectedPageSize));

        var actualProjects = await _service.GetAsync(parameters);
        var actualProject = actualProjects.First();

        Assert.AreEqual(expectedPageNumber, actualProjects.CurrentPage);
        Assert.AreEqual(expectedPageSize, actualProjects.PageSize);
        Assert.AreEqual(project.Id, actualProject.Id);
    }

    [TestCase]
    public async Task GetAsync_WithNoParameters_ShouldReturnPagedProjects()
    {
        var project = new Project
        {
            Id = 1,
            TeamId = 9,
            Title = "Blog",
            Type = "Website",
            Description = "Just a simple blog from small team"
        };

        var projects = new List<Project> { project };
        const int expectedPageNumber = 1;
        const int expectedPageSize = 1;

        _projectsRepository.Setup(repository => repository.GetAsync())
                           .ReturnsAsync(new PagedList<Project>(
                               projects,
                               projects.Count,
                               expectedPageNumber,
                               expectedPageSize));

        var actualProjects = await _service.GetAsync();
        var actualProject = actualProjects.First();

        Assert.AreEqual(project.Id, actualProject.Id);
    }

    [TestCase]
    public async Task GetByIdAsync_WhenExistingIdPassed_ShouldReturnProject()
    {
        var project = new Project
        {
            Id = 1,
            TeamId = 9,
            Title = "Blog",
            Type = "Website",
            Description = "Just a simple blog from small team"
        };

        _projectsRepository.Setup(repository => repository.GetCompleteEntityAsync(project.Id))
                           .ReturnsAsync(project);

        var actualProject = await _service.GetByIdAsync(project.Id);

        Assert.AreEqual(project.Id, actualProject.Id);
        Assert.AreEqual(project.TeamId, actualProject.TeamId);
        Assert.AreEqual(project.Title, actualProject.Title);
        Assert.AreEqual(project.Type, actualProject.Type);
        Assert.AreEqual(project.Description, actualProject.Description);
    }

    [TestCase]
    public void GetByIdAsync_WhenProjectNotFoundExceptionThrown_ShouldNotHandle()
    {
        const int projectId = 1;
        _projectsRepository.Setup(repository => repository.GetCompleteEntityAsync(projectId))
                           .Throws<EntityNotFoundException>();

        async Task<ProjectResponse> UnitAction() => await _service.GetByIdAsync(projectId);

        Assert.ThrowsAsync<EntityNotFoundException>(UnitAction);
    }

    [TestCase]
    public async Task InsertAsync_WhenValidProjectInserted_ShouldBeCompletedSuccessfully()
    {
        var request = new ProjectRequest
        {
            Id = 1,
            TeamId = 9,
            Title = "Blog",
            Type = "Website",
            Description = "Just a simple blog from small team"
        };

        _projectsRepository.Setup(repository => repository.InsertAsync(It.IsAny<Project>()))
                           .Returns(Task.CompletedTask);

        await _service.InsertAsync(request);

        _projectsRepository.Verify(r => r.InsertAsync(It.IsAny<Project>()), Times.Once);
        _unitOfWork.Verify(uof => uof.SaveChangesAsync(), Times.Once);
    }

    [TestCase]
    public void InsertAsync_WhenExceptionOccured_ShouldNotHandle()
    {
        var request = new ProjectRequest();
        _projectsRepository.Setup(repository => repository.InsertAsync(It.IsAny<Project>()))
                           .Throws<Exception>();

        async Task UnitAction() => await _service.InsertAsync(request);

        Assert.ThrowsAsync<Exception>(UnitAction);
    }

    [TestCase]
    public async Task UpdateAsync_WhenValidProjectUpdated_ShouldBeCompletedSuccessfully()
    {
        var request = new ProjectRequest
        {
            Id = 1,
            TeamId = 9,
            Title = "Blog",
            Type = "Website",
            Description = "Just a simple blog from small team"
        };

        _projectsRepository.Setup(repository => repository.UpdateAsync(It.IsAny<Project>()))
                           .Returns(Task.CompletedTask);

        await _service.UpdateAsync(request);

        _projectsRepository.Verify(r => r.UpdateAsync(It.IsAny<Project>()), Times.Once);
        _unitOfWork.Verify(uof => uof.SaveChangesAsync(), Times.Once);
    }

    [TestCase]
    public void UpdateAsync_WhenExceptionOccured_ShouldNotHandle()
    {
        var request = new ProjectRequest();
        _projectsRepository.Setup(repository => repository.UpdateAsync(It.IsAny<Project>()))
                           .Throws<Exception>();

        async Task UnitAction() => await _service.UpdateAsync(request);

        Assert.ThrowsAsync<Exception>(UnitAction);
    }

    [TestCase]
    public async Task DeleteAsync_WhenValidProjectDeleted_ShouldBeCompletedSuccessfully()
    {
        const int projectId = 1;
        _projectsRepository.Setup(repository => repository.DeleteAsync(It.IsAny<int>()))
                           .Returns(Task.CompletedTask);

        await _service.DeleteAsync(projectId);

        _projectsRepository.Verify(r => r.DeleteAsync(projectId), Times.Once);
        _unitOfWork.Verify(uof => uof.SaveChangesAsync(), Times.Once);
    }

    [TestCase]
    public void DeleteAsync_WhenExceptionOccured_ShouldNotHandle()
    {
        const int projectId = 1;
        _projectsRepository.Setup(repository => repository.DeleteAsync(It.IsAny<int>()))
                           .Throws<Exception>();

        async Task UnitAction() => await _service.DeleteAsync(projectId);

        Assert.ThrowsAsync<Exception>(UnitAction);
    }
}
