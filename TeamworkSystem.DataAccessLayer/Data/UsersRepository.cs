using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Models;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class UsersRepository : IRepository<User>
    {
        private readonly IConfiguration configuration;

        private string ConnectionString =>
            this.configuration.GetConnectionString("DefaultConnection");

        public async Task<IEnumerable<User>> GetAsync()
        {
            SqlParameter[] parameters = Array.Empty<SqlParameter>();

            await using var connection = new SqlConnection(this.ConnectionString);
            await using SqlCommand command = CreateCommandOfStoredProcedure(
                "SP_GetUsers",
                connection,
                parameters);

            connection.Open();
            await using SqlDataReader reader = await command.ExecuteReaderAsync();

            var users = new List<User>();
            while (await reader.ReadAsync())
            {
                users.Add(User.CreateInstanceFromReader(reader));
            }

            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            SqlParameter[]? parameters = new[]
            {
                new SqlParameter("@Id", id)
            };

            await using var connection = new SqlConnection(this.ConnectionString);
            await using SqlCommand command = CreateCommandOfStoredProcedure(
                "SP_GetUserById",
                connection,
                parameters);

            connection.Open();
            await using SqlDataReader reader = await command.ExecuteReaderAsync();
            await reader.ReadAsync();
            return User.CreateInstanceFromReader(reader);
        }

        public async Task InsertAsync(User user)
        {
            SqlParameter[]? parameters = new[]
            {
                new SqlParameter("@Name", user.Name),
                new SqlParameter("@Surname", user.Surname),
                new SqlParameter("@Profession",
                    (object?) user.Profession ?? DBNull.Value),
                new SqlParameter("@Specialization",
                    (object?) user.Specialization ?? DBNull.Value)
            };

            await using var connection = new SqlConnection(this.ConnectionString);
            await using SqlCommand command = CreateCommandOfStoredProcedure(
                "SP_InsertUser",
                connection,
                parameters);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync(int id, User user)
        {
            SqlParameter[]? parameters = new[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", user.Name),
                new SqlParameter("@Surname", user.Surname),
                new SqlParameter("@Profession",
                    (object?) user.Profession ?? DBNull.Value),
                new SqlParameter("@Specialization",
                    (object?) user.Specialization ?? DBNull.Value)
            };

            await using var connection = new SqlConnection(this.ConnectionString);
            await using SqlCommand command = CreateCommandOfStoredProcedure(
                "SP_UpdateUser",
                connection,
                parameters);

            await connection.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();

            if (rowsAffected == 0)
            {
                throw new Exception("No user with such id.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            SqlParameter[]? parameters = new[]
            {
                new SqlParameter("@Id", id)
            };

            await using var connection = new SqlConnection(this.ConnectionString);
            await using SqlCommand command = CreateCommandOfStoredProcedure(
                "SP_DeleteUser",
                connection,
                parameters);

            await connection.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();

            if (rowsAffected == 0)
            {
                throw new Exception("No user with such id.");
            }
        }

        private static SqlCommand CreateCommandOfStoredProcedure(
            string procedureName,
            SqlConnection connection,
            SqlParameter[] parameters)
        {
            var command = new SqlCommand
            {
                CommandText = procedureName,
                Connection = connection,
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddRange(parameters);
            return command;
        }

        public UsersRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}
