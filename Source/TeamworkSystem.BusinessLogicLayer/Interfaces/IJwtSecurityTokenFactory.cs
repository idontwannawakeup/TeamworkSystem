using System.IdentityModel.Tokens.Jwt;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces;

public interface IJwtSecurityTokenFactory
{
    JwtSecurityToken BuildToken(User user);
}
