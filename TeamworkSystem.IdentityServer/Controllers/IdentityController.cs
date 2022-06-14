using AutoMapper;
using IdentityServer4.Services;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.Identity.API.Models;
using TeamworkSystem.Identity.DataAccess.Entities;

namespace TeamworkSystem.IdentityServer.Controllers;

public class IdentityController : Controller
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IIdentityServerInteractionService _interactionService;

    public IdentityController(
        IPublishEndpoint publishEndpoint,
        IMapper mapper,
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        IIdentityServerInteractionService interactionService)
    {
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
        _signInManager = signInManager;
        _userManager = userManager;
        _interactionService = interactionService;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        var model = new LoginModel
        {
            ReturnUrl = returnUrl
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.FindByNameAsync(model.Username);
        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "User not found.");
        }

        var result = await _signInManager.PasswordSignInAsync(
            model.Username,
            model.Password,
            false,
            false);

        if (result.Succeeded)
        {
            return Redirect(model.ReturnUrl!);
        }

        ModelState.AddModelError(string.Empty, "Login error.");
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout(string logoutId)
    {
        await _signInManager.SignOutAsync();
        var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
        return Redirect(logoutRequest.PostLogoutRedirectUri);
    }
}
