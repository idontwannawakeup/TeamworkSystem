using System.Collections.Generic;
using System.Linq;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Infrastructure
{
    public class EntityParser<TEntity> : IEntityParser<TEntity>
        where TEntity : IEntity
    {
        public IEnumerable<string> Properties
        {
            get
            {
                return typeof(TEntity).GetProperties()
                    .Where(property => property.Name != "Id" &&
                                                 property.Name != "PrimaryKey")
                    .Select(property => property.Name);
            }
        }
    }
}
