using System.IdentityModel.Tokens.Jwt;
using TeamworkSystem.Identity.Persistence.People.Entities;

namespace TeamworkSystem.Identity.BusinessLogic.Interfaces;

public interface IJwtSecurityTokenFactory
{
    JwtSecurityToken BuildToken(User user);
}
