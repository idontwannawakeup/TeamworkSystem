using System.Data;
using Dapper;
using TeamworkSystem.Social.DataAccess.Entities;

namespace TeamworkSystem.Social.DataAccess.Data.Repositories;

public class FriendsRepository
{
    private readonly IDbConnection _connection;

    public FriendsRepository(IDbConnection connection) => _connection = connection;

    public async Task<IEnumerable<UserProfile>> GetAsync(Guid userId)
    {
        return await _connection.QueryAsync<UserProfile>(
            @"select * from UserProfile up
              join Friends f on up.Id = f.SecondId
              where f.FirstId = @UserId",
            new { UserId = userId });
    }
}
