using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TeamworkSystem.Identity.BusinessLogic.DTO.Requests;
using TeamworkSystem.Identity.BusinessLogic.DTO.Responses;
using TeamworkSystem.Identity.BusinessLogic.Interfaces;
using TeamworkSystem.Identity.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Identity.Persistence.People.Entities;
using TeamworkSystem.Identity.Persistence.People.Extensions;
using TeamworkSystem.Identity.Persistence.People.Interfaces;
using TeamworkSystem.Shared.Exceptions;

namespace TeamworkSystem.Identity.BusinessLogic.Services;

public class IdentityService : IIdentityService
{
    private readonly IMapper _mapper;
    private readonly IJwtSecurityTokenFactory _tokenFactory;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public IdentityService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IJwtSecurityTokenFactory tokenFactory)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _tokenFactory = tokenFactory;
        _userManager = _unitOfWork.UserManager;
    }

    public async Task<JwtResponse> SignInAsync(UserSignInRequest request)
    {
        var user = await _userManager.FindByNameOrThrowAsync(request.UserName);

        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new EntityNotFoundException("Incorrect username or password.");
        }

        var jwtToken = _tokenFactory.BuildToken(user);
        return new JwtResponse { Token = SerializeToken(jwtToken), UserId = user.Id };
    }

    public async Task<JwtResponse> SignUpAsync(UserSignUpRequest request)
    {
        var user = _mapper.Map<UserSignUpRequest, User>(request);
        var signUpResult = await _userManager.CreateAsync(user, request.Password);

        if (!signUpResult.Succeeded)
        {
            var errors = string.Join(
                Environment.NewLine,
                signUpResult.Errors.Select(error => error.Description));

            throw new ArgumentException(errors);
        }

        await _unitOfWork.SaveChangesAsync();

        var jwtToken = _tokenFactory.BuildToken(user);
        return new JwtResponse { UserId = user.Id, Token = SerializeToken(jwtToken) };
    }

    private static string SerializeToken(JwtSecurityToken jwtToken) =>
        new JwtSecurityTokenHandler().WriteToken(jwtToken);
}
