using System.Linq.Expressions;

namespace TeamworkSystem.Shared.Interfaces.Filters;

public interface IFilterCriterion<T>
{
    public bool Condition { get; }
    public Expression<Func<T, bool>> Expression { get; }
}
