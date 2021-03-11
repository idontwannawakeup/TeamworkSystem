using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TeamworkSystem.DataAccessLayer.Infrastructure;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : IIdentifiableEntity
    {
        protected readonly ISqlConnectionFactory SqlConnectionFactory;

        protected virtual IList<string> ExcludedProperties { get; } = new List<string>();

        protected abstract string TableName { get; }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            await using var connection = this.SqlConnectionFactory.Connection;
            return await connection.QueryAsync<TEntity>(
                "SP_GetAllFromTable",
                new
                {
                    this.TableName
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            await using var connection = this.SqlConnectionFactory.Connection;
            return await connection.QuerySingleAsync<TEntity>(
                "SP_GetByIdFromTable",
                new
                {
                    this.TableName,
                    Id = id
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task InsertAsync(TEntity obj)
        {
            IEnumerable<string> properties = new EntityParser<TEntity>().Properties
                .Where(property => !this.ExcludedProperties.Contains(property));

            string columnsString = string.Join(", ", properties);
            string propertiesString = string.Join(", ",
                properties.Select(property => $"@{property}"));

            await using var connection = this.SqlConnectionFactory.Connection;
            string query = await connection.QuerySingleAsync<string>(
                "SP_GenerateInsertQuery",
                new
                {
                    this.TableName,
                    ColumnsString = columnsString,
                    PropertiesString = propertiesString
                },
                commandType: CommandType.StoredProcedure);

            await connection.ExecuteAsync(query, obj, commandType: CommandType.Text);
        }

        public async Task UpdateAsync(int id, TEntity obj)
        {
            IEnumerable<string> properties = new EntityParser<TEntity>().Properties
                .Where(property => !this.ExcludedProperties.Contains(property));

            string columnsString = string.Join(", ",
                properties.Select(property => $"[{property}] = @{property}"));

            await using var connection = this.SqlConnectionFactory.Connection;
            string query = await connection.QuerySingleAsync<string>(
                "SP_GenerateUpdateQuery",
                new
                {
                    this.TableName,
                    ColumnsString = columnsString,
                    Id = id
                },
                commandType: CommandType.StoredProcedure);

            await connection.ExecuteAsync(query, obj, commandType: CommandType.Text);
        }

        public async Task DeleteAsync(int id)
        {
            await using var connection = this.SqlConnectionFactory.Connection;
            await connection.ExecuteAsync(
                "SP_DeleteByIdFromTable",
                new
                {
                    this.TableName,
                    Id = id
                },
                commandType: CommandType.StoredProcedure);
        }

        protected GenericRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.SqlConnectionFactory = sqlConnectionFactory;
        }
    }
}
