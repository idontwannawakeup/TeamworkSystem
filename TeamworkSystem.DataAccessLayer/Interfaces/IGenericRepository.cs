namespace TeamworkSystem.DataAccessLayer.Interfaces
{
    public interface IGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : IIdentifiableEntity
    {
    }
}
