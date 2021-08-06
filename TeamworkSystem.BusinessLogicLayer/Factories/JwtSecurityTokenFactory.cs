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
        private readonly JwtTokenConfiguration _jwtTokenConfiguration;

        public JwtSecurityTokenFactory(JwtTokenConfiguration jwtTokenConfiguration) =>
            _jwtTokenConfiguration = jwtTokenConfiguration;

        public JwtSecurityToken BuildToken(User user) => new(
            _jwtTokenConfiguration.Issuer,
            _jwtTokenConfiguration.Audience,
            GetClaims(user),
            expires: JwtTokenConfiguration.ExpirationDate,
            signingCredentials: _jwtTokenConfiguration.Credentials);

        private static IEnumerable<Claim> GetClaims(User user) => new List<Claim>
        {
            new(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Authentication, user.Id),
        };
    }
}
