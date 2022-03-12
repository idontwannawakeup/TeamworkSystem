using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Core.DataAccess.Interfaces.Repositories;
using TeamworkSystem.Shared.Exceptions;

namespace TeamworkSystem.Core.DataAccess.Data.Repositories;

public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly TeamworkSystemCoreDbContext DatabaseContext;
    protected readonly DbSet<TEntity> Table;

    public GenericRepository(TeamworkSystemCoreDbContext databaseContext)
    {
        DatabaseContext = databaseContext;
        Table = DatabaseContext.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync() => await Table.ToListAsync();

    public virtual async Task<TEntity> GetByIdAsync(int id) =>
        await Table.FindAsync(id)
        ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));

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
