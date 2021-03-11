using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly TeamworkSystemContext context;

        private readonly DbSet<TEntity> table;

        public Task<IEnumerable<TEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByKeyAsync(TKey key)
        {
            return await this.table.FindAsync(key);
        }

        public Task InsertAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TKey key, TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TKey key)
        {
            throw new NotImplementedException();
        }

        public GenericRepository(TeamworkSystemContext context)
        {
            this.context = context;
            this.table = this.context.Set<TEntity>();
        }
    }
}
