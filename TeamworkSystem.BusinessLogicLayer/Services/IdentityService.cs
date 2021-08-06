using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IMapper _mapper;
        private readonly IJwtSecurityTokenFactory _tokenFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public IdentityService(IUnitOfWork unitOfWork,
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
            var user = await _userManager.FindByNameAsync(request.UserName)
                       ?? throw new EntityNotFoundException(
                           $"{nameof(User)} with user name {request.UserName} not found.");

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
                var errors = string.Join("\n",
                                         signUpResult.Errors.Select(error => error.Description));

                throw new ArgumentException(errors);
            }

            await _unitOfWork.SaveChangesAsync();

            var jwtToken = _tokenFactory.BuildToken(user);
            return new JwtResponse { Token = SerializeToken(jwtToken) };
        }

        private static string SerializeToken(JwtSecurityToken jwtToken) =>
            new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}
