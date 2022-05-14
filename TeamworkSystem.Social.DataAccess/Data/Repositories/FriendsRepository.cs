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

    public async Task AddToFriendsAsync(Guid firstId, Guid secondId)
    {
        const string query = @"insert into Friends (FirstId, SecondId) values (@FirstId, @SecondId)";
        await _connection.ExecuteAsync(query, new { FirstId = firstId, SecondId = secondId });
        await _connection.ExecuteAsync(query, new { FirstId = secondId, SecondId = firstId });
    }

    public async Task DeleteFromFriendsAsync(Guid firstId, Guid secondId)
    {
        const string query = @"delete f from Friends f where f.FirstId = @FirstId and f.SecondId = @SecondId";
        await _connection.ExecuteAsync(query, new { FirstId = firstId, SecondId = secondId });
        await _connection.ExecuteAsync(query, new { FirstId = secondId, SecondId = firstId });
    }
}
