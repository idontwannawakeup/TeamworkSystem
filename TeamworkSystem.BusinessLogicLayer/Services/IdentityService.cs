using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TeamworkSystem.BusinessLogicLayer.Configurations;
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
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IJwtSecurityTokenFactory tokenFactory;

        private readonly UserManager<User> userManager;

        public async Task<JwtResponse> SignInAsync(UserSignInRequest request)
        {
            var user = await userManager.FindByNameAsync(request.UserName)
                ?? throw new EntityNotFoundException(
                    $"{nameof(User)} with user name {request.UserName} not found.");

            var jwtToken = tokenFactory.BuildToken(user);
            return new() { Token = SerializeToken(jwtToken) };
        }

        public async Task<JwtResponse> SignUpAsync(UserSignUpRequest request)
        {
            var user = mapper.Map<UserSignUpRequest, User>(request);
            var signUpResult = await userManager.CreateAsync(user, request.Password);

            if (!signUpResult.Succeeded)
            {
                string errors = string.Join("\n",
                    signUpResult.Errors.Select(error => error.Description));

                throw new ArgumentException(errors);
            }

            await unitOfWork.SaveChangesAsync();

            var jwtToken = tokenFactory.BuildToken(user);
            return new() { Token = SerializeToken(jwtToken) };
        }

        private static string SerializeToken(JwtSecurityToken jwtToken) =>
            new JwtSecurityTokenHandler().WriteToken(jwtToken);

        public IdentityService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IJwtSecurityTokenFactory tokenFactory)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.tokenFactory = tokenFactory;
            userManager = this.unitOfWork.UserManager;
        }
    }
}
