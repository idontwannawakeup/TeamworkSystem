using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly TeamworkSystemContext databaseContext;

        protected readonly DbSet<TEntity> table;

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.table.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await this.table.FindAsync(id)
                ?? throw new Exception($"{typeof(TEntity).Name} not found.");
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await this.table.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => this.table.Update(entity));
        }

        public virtual async Task DeleteAsync(int id)
        {
            TEntity entity = await this.table.FindAsync(id)
                ?? throw new Exception($"{typeof(TEntity).Name} not found.");

            await Task.Run(() => this.table.Remove(entity));
        }

        public GenericRepository(TeamworkSystemContext databaseContext)
        {
            this.databaseContext = databaseContext;
            this.table = this.databaseContext.Set<TEntity>();
        }
    }
}
