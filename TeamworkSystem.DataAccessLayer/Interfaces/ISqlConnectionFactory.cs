using System.Data.SqlClient;

namespace TeamworkSystem.DataAccessLayer.Interfaces
{
    public interface ISqlConnectionFactory
    {
        SqlConnection Connection { get; }
    }
}
