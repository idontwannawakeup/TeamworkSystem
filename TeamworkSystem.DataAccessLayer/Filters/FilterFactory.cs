using TeamworkSystem.DataAccessLayer.Interfaces.Filters;

namespace TeamworkSystem.DataAccessLayer.Filters;

public class FilterFactory : IFilterFactory
{
    private readonly IFilterCriteriaFactory _criteriaFactory;

    public FilterFactory(IFilterCriteriaFactory criteriaFactory) =>
        _criteriaFactory = criteriaFactory;

    public IFilter<T> Get<T, TParams>(TParams parameters) where TParams : IFilterParameters<T> =>
        new Filter<T>(_criteriaFactory.Get<T, TParams>(parameters));
}
