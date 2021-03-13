using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamworkSystem.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task InsertAsync(TEntity obj);

        Task UpdateAsync(int id, TEntity obj);

        Task DeleteAsync(int id);
    }
}
