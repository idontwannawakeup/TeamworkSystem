using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories;

public class RatingAverageScores
{
    public string ToId { get; set; }
    public double SkillsAverage { get; set; }
    public double SocialAverage { get; set; }
    public double ResponsibilityAverage { get; set; }
    public double PunctualityAverage { get; set; }
}

public class RatingsDapperRepository
{
    private readonly IDbConnection _connection;

    public RatingsDapperRepository(IDbConnection connection) => _connection = connection;

    public async Task<RatingAverageScores> GetAverageScoresForUserAsync(string ratedUserId)
    {
        var ratings = await _connection.QueryAsync<RatingAverageScores>(
            @"select r.ToId,
                  AVG(r.Skills) as SkillsAverage,
                  AVG(r.Social) as SocialAverage,
                  AVG(r.Responsibility) as ResponsibilityAverage,
                  AVG(r.Punctuality) as PunctualityAverage
              from Ratings r
              where r.ToId = @RatedUserId
              group by r.ToId",
            new { RatedUserId = ratedUserId });

        return ratings.SingleOrDefault();
    }

    public async Task<IEnumerable<RatingAverageScores>> GetAverageScoresForOtherUsersAsync(string ratedUserId)
    {
        return await _connection.QueryAsync<RatingAverageScores>(
            @"select r.ToId, AVG(r.Skills) as AverageSkills
              from Ratings r
              where r.ToId <> @RatedUserId
              group by r.ToId",
            new { RatedUserId = ratedUserId });
    }
}
