using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories;

public class FriendsRepository
{
    private readonly IDbConnection _connection;

    public FriendsRepository(IDbConnection connection) => _connection = connection;

    public async Task<IEnumerable<User>> GetAsync(string userId)
    {
        return await _connection.QueryAsync<User>(
            @"select * from AspNetUsers up
              join Friends f on up.Id = f.SecondId
              where f.FirstId = @UserId",
            new { UserId = userId });
    }

    // public async Task<PagedList<User>> GetAsync(Guid userId, FriendsParameters parameters)
    // {
    //     var queryBuilder = new StringBuilder(
    //         @"select * from AspNetUsers up
    //           join Friends f on up.Id = f.SecondId
    //           join AspNetUsers fup on fup.Id = f.SecondId
    //           where f.FirstId = @UserId");
    //
    //     if (!string.IsNullOrWhiteSpace(parameters.LastName))
    //     {
    //         queryBuilder.Append(" and fup.LastName like '%' + @LastName + '%'");
    //     }
    //
    //     var enumerable = await _connection.QueryAsync<UserProfile>(
    //         queryBuilder.ToString(),
    //         new { UserId = userId });
    //
    //     var friends = enumerable as UserProfile[] ?? enumerable.ToArray();
    //     int pageNumber = parameters.PageNumber, pageSize = parameters.PageSize;
    //     return new PagedList<UserProfile>(
    //         friends.Skip((pageNumber - 1) * pageSize).Take(pageSize),
    //         friends.Length,
    //         pageNumber,
    //         pageSize);
    // }

    public async Task AddToFriendsAsync(string firstId, string secondId)
    {
        const string query = @"insert into Friends (FirstId, SecondId) values (@FirstId, @SecondId)";
        await _connection.ExecuteAsync(query, new { FirstId = firstId, SecondId = secondId });
        await _connection.ExecuteAsync(query, new { FirstId = secondId, SecondId = firstId });
    }

    public async Task DeleteFromFriendsAsync(string firstId, string secondId)
    {
        const string query = @"delete f from Friends f where f.FirstId = @FirstId and f.SecondId = @SecondId";
        await _connection.ExecuteAsync(query, new { FirstId = firstId, SecondId = secondId });
        await _connection.ExecuteAsync(query, new { FirstId = secondId, SecondId = firstId });
    }
}
