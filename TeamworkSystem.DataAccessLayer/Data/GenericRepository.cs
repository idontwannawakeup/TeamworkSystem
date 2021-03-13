using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly TeamworkSystemContext context;

        private readonly DbSet<TEntity> table;

        public Task<IEnumerable<TEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await this.table.FindAsync(id);
        }

        public Task InsertAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
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
