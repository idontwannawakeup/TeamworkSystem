using System;
using System.Threading.Tasks;
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

        Assert.IsInstanceOf<ActionResult<PagedList<TeamResponse>>>(result);
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
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

        Assert.IsInstanceOf<ActionResult<PagedList<TeamResponse>>>(result);
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
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

        Assert.IsInstanceOf<ActionResult<TeamResponse>>(result);
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
        Assert.AreEqual(team.Id, actualTeam?.Id);
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

        Assert.IsInstanceOf<ActionResult<TeamResponse>>(result);
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
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

        Assert.IsInstanceOf<ActionResult<TeamResponse>>(result);
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
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

        Assert.IsInstanceOf<ActionResult>(result);
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
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

        Assert.IsInstanceOf<ActionResult>(result);
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
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

        Assert.IsInstanceOf<ActionResult>(result);
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
    }
}
