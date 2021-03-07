using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Models;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class RatingsRepository : IRepository<Rating, (int, int)>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;
        
        public async Task<IEnumerable<Rating>> GetAsync()
        {
            await using var connection = this.sqlConnectionFactory.Connection;
            return await connection.QueryAsync<Rating>(
                "SP_GetAllFromTable", 
                new
                {
                    TableName = "Ratings"
                }, 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Rating> GetByKeyAsync((int, int) key)
        {
            (int @from, int to) = key;
            await using var connection = this.sqlConnectionFactory.Connection;
            return await connection.QuerySingleAsync<Rating>(
                "SP_GetRatingByKey",
                new
                {
                    From = @from,
                    To = to
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task InsertAsync(Rating rating)
        {
            await using var connection = this.sqlConnectionFactory.Connection;
            await connection.ExecuteAsync("SP_InsertRating",
                rating,
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateAsync((int, int) key, Rating rating)
        {
            (int @from, int to) = key;
            await using var connection = this.sqlConnectionFactory.Connection;
            await connection.ExecuteAsync("SP_UpdateRating",
                new
                {
                    From = @from,
                    To = to,
                    rating.Social,
                    rating.Skills,
                    rating.Responsibility,
                    rating.Punctuality,
                    rating.Comment
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync((int, int) key)
        {
            (int @from, int to) = key;
            await using var connection = this.sqlConnectionFactory.Connection;
            await connection.ExecuteAsync("SP_DeleteRating",
                new
                {
                    From = @from,
                    To = to
                },
                commandType: CommandType.StoredProcedure);
        }

        public RatingsRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }
    }
}