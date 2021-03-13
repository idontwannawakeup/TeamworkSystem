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
        private readonly TeamworkSystemContext context;

        private readonly DbSet<TEntity> table;

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.table.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await this.table.FindAsync(id)
                ?? throw new Exception("Entity not found.");
        }

        public async Task InsertAsync(TEntity entity)
        {
            await this.table.AddAsync(entity);
            await this.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this.table.Update(entity);
            await this.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TEntity objToDelete = await this.table.FindAsync(id)
                ?? throw new Exception("Entity not found.");

            this.table.Remove(objToDelete);
            await this.SaveChangesAsync();
        }

        private async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public GenericRepository(TeamworkSystemContext context)
        {
            this.context = context;
            this.table = this.context.Set<TEntity>();
        }
    }
}
