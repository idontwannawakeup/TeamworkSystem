﻿using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;
using TeamworkSystem.WebAPI.Controllers;

namespace TeamworkSystem.Tests.Controllers;

public class TeamsControllerTests
{
    private TeamsController _controller = default!;
    private Mock<ITeamsService> _service = default!;

    [SetUp]
    public void Initialize()
    {
        _service = new Mock<ITeamsService>();

        _controller = new TeamsController(_service.Object)
        {
            ControllerContext = { HttpContext = new DefaultHttpContext() }
        };
    }

    [TestCase]
    public async Task GetAsync_WhenCalled_ReturnsActionResultWithTeams()
    {
        const int expectedStatusCode = StatusCodes.Status200OK;
        var parameters = new TeamsParameters();
        var teamsPage = new PagedList<TeamResponse>(Array.Empty<TeamResponse>(), 0, 1, 1);
        _service.Setup(service => service.GetAsync(It.IsAny<TeamsParameters>()))
                .ReturnsAsync(teamsPage);

        var result = await _controller.GetAsync(parameters);
        var objectResult = result.Result as ObjectResult;
        var actualStatusCode = objectResult?.StatusCode;

        result.Should().BeOfType<ActionResult<PagedList<TeamResponse>>>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task GetAsync_WhenExceptionThrown_ReturnsInternalServerError()
    {
        const int expectedStatusCode = StatusCodes.Status500InternalServerError;
        var parameters = new TeamsParameters();
        _service.Setup(service => service.GetAsync(It.IsAny<TeamsParameters>()))
                .Throws<Exception>();

        var result = await _controller.GetAsync(parameters);
        var objectResult = result.Result as ObjectResult;
        var actualStatusCode = objectResult?.StatusCode;

        result.Should().BeOfType<ActionResult<PagedList<TeamResponse>>>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task GetByIdAsync_WhenExistingIdPassed_ReturnsOkWithTeam()
    {
        const int expectedStatusCode = StatusCodes.Status200OK;
        var teamId = Random.Shared.Next(10);
        var team = new TeamResponse { Id = teamId };
        _service.Setup(service => service.GetByIdAsync(teamId)).ReturnsAsync(team);

        var result = await _controller.GetByIdAsync(teamId);
        var objectResult = result.Result as ObjectResult;
        var actualStatusCode = objectResult?.StatusCode;
        var actualTeam = objectResult?.Value as TeamResponse;

        result.Should().BeOfType<ActionResult<TeamResponse>>();
        actualStatusCode.Should().Be(expectedStatusCode);
        actualTeam?.Id.Should().Be(team.Id);
    }

    [TestCase]
    public async Task GetByIdAsync_WhenNonExistingIdPassed_ReturnsNotFound()
    {
        const int expectedStatusCode = StatusCodes.Status404NotFound;
        var teamId = Random.Shared.Next(10);
        _service.Setup(service => service.GetByIdAsync(teamId)).Throws<EntityNotFoundException>();

        var result = await _controller.GetByIdAsync(teamId);
        var objectResult = result.Result as ObjectResult;
        var actualStatusCode = objectResult?.StatusCode;

        result.Should().BeOfType<ActionResult<TeamResponse>>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task GetByIdAsync_WhenExceptionThrown_ReturnsInternalServerError()
    {
        const int expectedStatusCode = StatusCodes.Status500InternalServerError;
        var teamId = Random.Shared.Next(10);
        _service.Setup(service => service.GetByIdAsync(It.IsAny<int>()))
                .Throws<Exception>();

        var result = await _controller.GetByIdAsync(teamId);
        var objectResult = result.Result as ObjectResult;
        var actualStatusCode = objectResult?.StatusCode;

        result.Should().BeOfType<ActionResult<TeamResponse>>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task InsertAsync_WhenValidTeamPassed_ReturnsOk()
    {
        const int expectedStatusCode = StatusCodes.Status200OK;
        var teamId = Random.Shared.Next(10);
        var leaderId = Guid.NewGuid().ToString();
        var team = new TeamRequest { Id = teamId, LeaderId = leaderId };
        _service.Setup(service => service.InsertAsync(team)).Returns(Task.CompletedTask);

        var result = await _controller.InsertAsync(team);
        var okResult = result as OkResult;
        var actualStatusCode = okResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<OkResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task InsertAsync_WhenLeaderIdOfTeamDoesntExist_ReturnsNotFound()
    {
        const int expectedStatusCode = StatusCodes.Status404NotFound;
        var teamId = Random.Shared.Next(10);
        var leaderId = Guid.NewGuid().ToString();
        var team = new TeamRequest { Id = teamId, LeaderId = leaderId };
        _service.Setup(service => service.InsertAsync(team)).Throws<EntityNotFoundException>();

        var result = await _controller.InsertAsync(team);
        var okResult = result as NotFoundObjectResult;
        var actualStatusCode = okResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<NotFoundObjectResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task InsertAsync_WhenExceptionThrown_ReturnsInternalServerError()
    {
        const int expectedStatusCode = StatusCodes.Status500InternalServerError;
        var teamId = Random.Shared.Next(10);
        var team = new TeamRequest { Id = teamId };
        _service.Setup(service => service.InsertAsync(It.IsAny<TeamRequest>())).Throws<Exception>();

        var result = await _controller.InsertAsync(team);
        var objectResult = result as ObjectResult;
        var actualStatusCode = objectResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<ObjectResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task UpdateAsync_WhenValidTeamPassed_ReturnsOk()
    {
        const int expectedStatusCode = StatusCodes.Status200OK;
        var teamId = Random.Shared.Next(10);
        var leaderId = Guid.NewGuid().ToString();
        var team = new TeamRequest { Id = teamId, LeaderId = leaderId };
        _service.Setup(service => service.UpdateAsync(team)).Returns(Task.CompletedTask);

        var result = await _controller.UpdateAsync(team);
        var okResult = result as OkResult;
        var actualStatusCode = okResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<OkResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task UpdateAsync_WhenExceptionThrown_ReturnsInternalServerError()
    {
        const int expectedStatusCode = StatusCodes.Status500InternalServerError;
        var teamId = Random.Shared.Next(10);
        var team = new TeamRequest { Id = teamId };
        _service.Setup(service => service.UpdateAsync(It.IsAny<TeamRequest>())).Throws<Exception>();

        var result = await _controller.UpdateAsync(team);
        var objectResult = result as ObjectResult;
        var actualStatusCode = objectResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<ObjectResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task DeleteAsync_WhenValidTeamPassed_ReturnsOk()
    {
        const int expectedStatusCode = StatusCodes.Status200OK;
        var teamId = Random.Shared.Next(10);
        _service.Setup(service => service.DeleteAsync(teamId)).Returns(Task.CompletedTask);

        var result = await _controller.DeleteAsync(teamId);
        var okResult = result as OkResult;
        var actualStatusCode = okResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<OkResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task DeleteAsync_WhenTeamNotFound_ReturnsNotFound()
    {
        const int expectedStatusCode = StatusCodes.Status404NotFound;
        var teamId = Random.Shared.Next(10);
        _service.Setup(service => service.DeleteAsync(teamId)).Throws<EntityNotFoundException>();

        var result = await _controller.DeleteAsync(teamId);
        var okResult = result as NotFoundObjectResult;
        var actualStatusCode = okResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<NotFoundObjectResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task DeleteAsync_WhenExceptionThrown_ReturnsInternalServerError()
    {
        const int expectedStatusCode = StatusCodes.Status500InternalServerError;
        var teamId = Random.Shared.Next(10);
        _service.Setup(service => service.DeleteAsync(teamId)).Throws<Exception>();

        var result = await _controller.DeleteAsync(teamId);
        var objectResult = result as ObjectResult;
        var actualStatusCode = objectResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<ObjectResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task AddMemberAsync_WhenValidIdsPassed_ReturnsOk()
    {
        const int expectedStatusCode = StatusCodes.Status200OK;
        var teamId = Random.Shared.Next(10);
        var memberId = Guid.NewGuid().ToString();
        var request = new TeamMemberRequest { TeamId = teamId, UserId = memberId };
        _service.Setup(service => service.AddMemberAsync(request)).Returns(Task.CompletedTask);

        var result = await _controller.AddMemberAsync(request);
        var okResult = result as OkResult;
        var actualStatusCode = okResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<OkResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task AddMemberAsync_WhenTeamOrMemberNotFound_ReturnsNotFound()
    {
        const int expectedStatusCode = StatusCodes.Status404NotFound;
        var teamId = Random.Shared.Next(10);
        var memberId = Guid.NewGuid().ToString();
        var request = new TeamMemberRequest { TeamId = teamId, UserId = memberId };
        _service.Setup(service => service.AddMemberAsync(request))
                .Throws<EntityNotFoundException>();

        var result = await _controller.AddMemberAsync(request);
        var okResult = result as NotFoundObjectResult;
        var actualStatusCode = okResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<NotFoundObjectResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task AddMemberAsync_WhenExceptionThrown_ReturnsInternalServerError()
    {
        const int expectedStatusCode = StatusCodes.Status500InternalServerError;
        var teamId = Random.Shared.Next(10);
        var memberId = Guid.NewGuid().ToString();
        var request = new TeamMemberRequest { TeamId = teamId, UserId = memberId };
        _service.Setup(service => service.AddMemberAsync(It.IsAny<TeamMemberRequest>()))
                .Throws<Exception>();

        var result = await _controller.AddMemberAsync(request);
        var objectResult = result as ObjectResult;
        var actualStatusCode = objectResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<ObjectResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task DeleteMemberAsync_WhenValidIdsPassed_ReturnsOk()
    {
        const int expectedStatusCode = StatusCodes.Status200OK;
        var teamId = Random.Shared.Next(10);
        var memberId = Guid.NewGuid().ToString();
        var request = new TeamMemberRequest { TeamId = teamId, UserId = memberId };
        _service.Setup(service => service.DeleteMemberAsync(request)).Returns(Task.CompletedTask);

        var result = await _controller.DeleteMemberAsync(request.TeamId, request.UserId);
        var okResult = result as OkResult;
        var actualStatusCode = okResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<OkResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task DeleteMemberAsync_WhenTeamOrMemberNotFound_ReturnsNotFound()
    {
        const int expectedStatusCode = StatusCodes.Status404NotFound;
        var teamId = Random.Shared.Next(10);
        var memberId = Guid.NewGuid().ToString();
        var request = new TeamMemberRequest { TeamId = teamId, UserId = memberId };
        _service.Setup(service => service.DeleteMemberAsync(It.IsAny<TeamMemberRequest>()))
                .Throws<EntityNotFoundException>();

        var result = await _controller.DeleteMemberAsync(request.TeamId, request.UserId);
        var notFoundResult = result as NotFoundObjectResult;
        var actualStatusCode = notFoundResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<NotFoundObjectResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [TestCase]
    public async Task DeleteMemberAsync_WhenExceptionThrown_ReturnsInternalServerError()
    {
        const int expectedStatusCode = StatusCodes.Status500InternalServerError;
        var teamId = Random.Shared.Next(10);
        var memberId = Guid.NewGuid().ToString();
        var request = new TeamMemberRequest { TeamId = teamId, UserId = memberId };
        _service.Setup(service => service.DeleteMemberAsync(It.IsAny<TeamMemberRequest>()))
                .Throws<Exception>();

        var result = await _controller.DeleteMemberAsync(request.TeamId, request.UserId);
        var objectResult = result as ObjectResult;
        var actualStatusCode = objectResult?.StatusCode;

        result.Should().BeAssignableTo<ActionResult>();
        result.Should().BeOfType<ObjectResult>();
        actualStatusCode.Should().Be(expectedStatusCode);
    }
}
