using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamworkSystem.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetByKeyAsync(TKey key);

        Task InsertAsync(TEntity obj);

        Task UpdateAsync(TKey key, TEntity obj);

        Task DeleteAsync(TKey key);
    }
}
