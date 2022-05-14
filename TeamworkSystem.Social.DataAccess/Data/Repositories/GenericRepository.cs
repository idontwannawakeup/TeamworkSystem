using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Shared.Exceptions;
using TeamworkSystem.Shared.Interfaces;

namespace TeamworkSystem.Social.DataAccess.Data.Repositories;

public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly TeamworkSystemSocialDbContext DatabaseContext;
    protected readonly DbSet<TEntity> Table;

    public GenericRepository(TeamworkSystemSocialDbContext databaseContext)
    {
        DatabaseContext = databaseContext;
        Table = DatabaseContext.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync() => await Table.ToListAsync();

    public virtual async Task<TEntity> GetByIdAsync(Guid id) =>
        await Table.FindAsync(id)
        ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));

    public abstract Task<TEntity> GetCompleteEntityAsync(Guid id);

    public virtual async Task InsertAsync(TEntity entity) => await Table.AddAsync(entity);

    public virtual async Task UpdateAsync(TEntity entity) =>
        await Task.Run(() => Table.Update(entity));

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        Table.Remove(entity);
    }

    protected static string GetEntityNotFoundErrorMessage(Guid id) =>
        $"{typeof(TEntity).Name} with id {id} not found.";
}
