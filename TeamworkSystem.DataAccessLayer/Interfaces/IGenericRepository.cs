namespace TeamworkSystem.DataAccessLayer.Interfaces
{
    public interface IGenericRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : IIdentifiableEntity
    {
    }
}
