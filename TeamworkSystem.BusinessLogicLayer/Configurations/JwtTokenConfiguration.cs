using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TeamworkSystem.BusinessLogicLayer.Configurations;

public class JwtTokenConfiguration
{
    private readonly IConfiguration _configuration;

    public JwtTokenConfiguration(IConfiguration configuration) =>
        _configuration = configuration;

    public string Issuer => _configuration["JwtIssuer"];
    public string Audience => _configuration["JwtAudience"];
    public static DateTime ExpirationDate => DateTime.UtcNow.AddYears(1);

    public SymmetricSecurityKey Key =>
        new(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));

    public SigningCredentials Credentials =>
        new(Key, SecurityAlgorithms.HmacSha256);
}
