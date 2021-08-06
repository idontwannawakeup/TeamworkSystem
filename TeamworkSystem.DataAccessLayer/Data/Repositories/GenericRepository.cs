using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TeamworkSystemContext DatabaseContext;
        protected readonly DbSet<TEntity> Table;

        public GenericRepository(TeamworkSystemContext databaseContext)
        {
            DatabaseContext = databaseContext;
            Table = DatabaseContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync() => await Table.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(int id) =>
            await Table.FindAsync(id) ??
            throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));

        public abstract Task<TEntity> GetCompleteEntityAsync(int id);

        public virtual async Task InsertAsync(TEntity entity) => await Table.AddAsync(entity);

        public virtual async Task UpdateAsync(TEntity entity) =>
            await Task.Run(() => Table.Update(entity));

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Table.Remove(entity);
        }

        protected static string GetEntityNotFoundErrorMessage(int id) =>
            $"{typeof(TEntity).Name} with id {id} not found.";
    }
}
