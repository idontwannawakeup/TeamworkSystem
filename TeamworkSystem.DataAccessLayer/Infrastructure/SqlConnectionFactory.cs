using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Infrastructure
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration configuration;

        public SqlConnection Connection =>
            new(this.configuration.GetConnectionString("DefaultConnection"));

        public SqlConnectionFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}
