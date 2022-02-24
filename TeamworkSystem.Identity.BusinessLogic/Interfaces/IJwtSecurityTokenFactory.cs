using System.IdentityModel.Tokens.Jwt;
using TeamworkSystem.Identity.DataAccess.Entities;

namespace TeamworkSystem.Identity.BusinessLogic.Interfaces;

public interface IJwtSecurityTokenFactory
{
    JwtSecurityToken BuildToken(User user);
}
