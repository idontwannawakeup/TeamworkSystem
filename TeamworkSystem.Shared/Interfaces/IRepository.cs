namespace TeamworkSystem.Shared.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> GetCompleteEntityAsync(Guid id);
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
}
