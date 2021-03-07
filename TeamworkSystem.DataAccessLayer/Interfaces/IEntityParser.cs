using System.Collections.Generic;

namespace TeamworkSystem.DataAccessLayer.Interfaces
{
    public interface IEntityParser<TEntity> where TEntity : IEntity
    {
        IEnumerable<string> Properties { get; }
    }
}
