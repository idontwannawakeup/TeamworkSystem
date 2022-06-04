using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
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
}
