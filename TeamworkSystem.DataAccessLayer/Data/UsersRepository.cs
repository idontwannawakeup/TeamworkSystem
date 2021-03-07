﻿using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Models;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class UsersRepository : GenericRepository<User>
    {
        protected override string TableName { get; } = "Users";

        public UsersRepository(ISqlConnectionFactory sqlConnectionFactory)
            : base(sqlConnectionFactory)
        {
        }
    }
}
