using System.Data;
using System.Text;
using Dapper;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Interfaces.Repositories;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.DataAccess.Data.Repositories;

public class FriendsRepository : IFriendsRepository
{
    private readonly IDbConnection _connection;

    public FriendsRepository(IDbConnection connection) => _connection = connection;

    public async Task<IEnumerable<UserProfile>> GetAsync(Guid userId)
    {
        return await _connection.QueryAsync<UserProfile>(
            @"select * from UserProfiles up
              join Friends f on up.Id = f.SecondId
              where f.FirstId = @UserId",
            new { UserId = userId });
    }

    public async Task<PagedList<UserProfile>> GetAsync(Guid userId, FriendsParameters parameters)
    {
        var queryBuilder = new StringBuilder(
            @"select * from UserProfiles up
              join Friends f on up.Id = f.SecondId
              join UserProfiles fup on fup.Id = f.SecondId
              where f.FirstId = @UserId");

        if (!string.IsNullOrWhiteSpace(parameters.LastName))
        {
            queryBuilder.Append(" and fup.LastName like '%' + @LastName + '%'");
        }

        var enumerable = await _connection.QueryAsync<UserProfile>(
            queryBuilder.ToString(),
            new { UserId = userId });

        var friends = enumerable as UserProfile[] ?? enumerable.ToArray();
        int pageNumber = parameters.PageNumber, pageSize = parameters.PageSize;
        return new PagedList<UserProfile>(
            friends.Skip((pageNumber - 1) * pageSize).Take(pageSize),
            friends.Length,
            pageNumber,
            pageSize);
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
