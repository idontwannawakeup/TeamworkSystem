using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TeamworkSystem.BusinessLogicLayer.Configurations
{
    public class JwtTokenConfiguration
    {
        private readonly IConfiguration configuration;

        public static DateTime ExpirationDate => DateTime.UtcNow.AddYears(1);

        public SymmetricSecurityKey Key =>
            new(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));

        public SigningCredentials Credentials =>
            new(Key, SecurityAlgorithms.HmacSha256);

        public JwtTokenConfiguration(IConfiguration configuration) =>
            this.configuration = configuration;
    }
}
