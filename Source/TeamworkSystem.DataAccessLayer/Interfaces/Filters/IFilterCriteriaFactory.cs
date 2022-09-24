namespace TeamworkSystem.DataAccessLayer.Interfaces.Filters;

public interface IFilterCriteriaFactory
{
    IReadOnlyCollection<IFilterCriterion<T>> Get<T, TParams>(TParams parameters)
        where TParams : IFilterParameters<T>;
}
