using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

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

        public virtual async Task<PagedList<TEntity>> GetPageAsync(PaginationParameters parameters)
        {
            return await PagedList<TEntity>.ToPagedListAsync(
                this.table,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await this.table.FindAsync(id)
                ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
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
                ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));

            await Task.Run(() => this.table.Remove(entity));
        }

        protected static string GetEntityNotFoundErrorMessage(int id) =>
            $"{typeof(TEntity).Name} with id {id} not found.";

        public GenericRepository(TeamworkSystemContext databaseContext)
        {
            this.databaseContext = databaseContext;
            this.table = this.databaseContext.Set<TEntity>();
        }
    }
}
