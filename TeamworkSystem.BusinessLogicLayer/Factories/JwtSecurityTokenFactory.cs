using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TeamworkSystem.BusinessLogicLayer.Configurations;
using TeamworkSystem.BusinessLogicLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.BusinessLogicLayer.Factories
{
    public class JwtSecurityTokenFactory : IJwtSecurityTokenFactory
    {
        private readonly JwtTokenConfiguration jwtTokenConfiguration;

        public JwtSecurityToken BuildToken(User user) => new(
            issuer: jwtTokenConfiguration.Issuer,
            audience: jwtTokenConfiguration.Audience,
            claims: GetClaims(user),
            expires: JwtTokenConfiguration.ExpirationDate,
            signingCredentials: jwtTokenConfiguration.Credentials);

        private static List<Claim> GetClaims(User user) => new()
        {
            new(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Authentication, user.Id),
        };

        public JwtSecurityTokenFactory(JwtTokenConfiguration jwtTokenConfiguration) =>
            this.jwtTokenConfiguration = jwtTokenConfiguration;
    }
}
