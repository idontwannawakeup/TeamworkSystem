using System.Data;
using System.Text;
using Dapper;
using TeamworkSystem.Shared.Exceptions;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Interfaces.Repositories;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.DataAccess.Data.Repositories;

public class RatingsRepository : IRatingsRepository
{
    private readonly IDbConnection _connection;

    public RatingsRepository(IDbConnection connection) => _connection = connection;

    public async Task<IEnumerable<Rating>> GetAsync()
    {
        return await _connection.QueryAsync<Rating>("select * from Ratings");
    }

    public async Task<Rating> GetByIdAsync(Guid id)
    {
        return await _connection.QuerySingleAsync<Rating>(
            "select * from Ratings r where r.Id = @Id",
            new { Id = id });
    }

    public async Task<Rating> GetCompleteEntityAsync(Guid id)
    {
        var ratings = await _connection.QueryAsync<Rating, UserProfile, UserProfile, Rating>(
            @"select *
              from Ratings r
              join UserProfiles upf on r.FromId = upf.Id
              join UserProfiles upt on r.ToId = upt.Id",
            (rating, from, to) =>
            {
                rating.From = from;
                rating.To = to;
                return rating;
            });

        return ratings.SingleOrDefault()
               ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }

    public async Task InsertAsync(Rating rating)
    {
        await _connection.ExecuteAsync(
            @"insert into Ratings
                (Id, FromId, ToId, Social, Skills, Responsibility, Punctuality, Comment) values
                (@Id, @FromId, @ToId, @Social, @Skills, @Responsibility, @Punctuality, @Comment)",
            new DynamicParameters(rating));
    }

    public async Task UpdateAsync(Rating rating)
    {
        await _connection.ExecuteAsync(
            @"update Ratings r set
                r.Social = @Social,
                r.Skills = @Skills,
                r.Responsibility = @Responsibility,
                r.Punctuality = @Punctuality,
                r.Comment = @Comment
              where r.Id = @Id",
            new DynamicParameters(rating));
    }

    public async Task DeleteAsync(Guid id)
    {
        await _connection.ExecuteAsync(
            "delete from Ratings r where r.Id = @Id",
            new { Id = id });
    }

    public async Task<PagedList<Rating>> GetAsync(RatingsParameters parameters)
    {
        var queryBuilder = new StringBuilder(
            @"select *
              from Ratings r
              join UserProfiles upf on r.FromId = upf.Id
              join UserProfiles upt on r.ToId = upt.Id");

        if (parameters.RatedUserId is not null)
        {
            queryBuilder.Append(" where r.ToId = @RatedUserId");
        }

        var enumerable = await _connection.QueryAsync<Rating, UserProfile, UserProfile, Rating>(
            queryBuilder.ToString(),
            (rating, from, to) =>
            {
                rating.From = from;
                rating.To = to;
                return rating;
            },
            new { parameters.RatedUserId });

        var ratings = enumerable as Rating[] ?? enumerable.ToArray();
        int pageNumber = parameters.PageNumber, pageSize = parameters.PageSize;
        return new PagedList<Rating>(
            ratings.Skip((pageNumber - 1) * pageSize).Take(pageSize),
            ratings.Length,
            pageNumber,
            pageSize);
    }

    public async Task<IEnumerable<Rating>> GetRatingsFromUserAsync(Guid userId)
    {
        return await _connection.QueryAsync<Rating>(
            "select * from Ratings r where r.FromId = @FromId",
            new { FromId = userId });
    }

    public async Task<IEnumerable<Rating>> GetRatingsForUserAsync(Guid userId)
    {
        return await _connection.QueryAsync<Rating>(
            "select * from Ratings r where r.ToId = @FromId",
            new { FromId = userId });
    }

    private static string GetEntityNotFoundErrorMessage(Guid id) =>
        $"{nameof(Rating)} with id {id} not found.";
}
