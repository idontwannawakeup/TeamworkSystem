using TeamworkSystem.DataAccessLayer.Interfaces.Filters;

namespace TeamworkSystem.DataAccessLayer.Filters;

public class FilterCriteriaFactory : IFilterCriteriaFactory
{
    public IReadOnlyCollection<IFilterCriterion<T>> Get<T, TParams>(TParams parameters)
        where TParams : IFilterParameters<T> =>
        typeof(T).Assembly
                 .GetTypes()
                 .Where(Implements<IFilterCriterion<T>>)
                 .Select(CreateInstance<T, TParams>(parameters))
                 .ToList();

    private static bool Implements<TInterface>(Type type) where TInterface : class =>
        typeof(TInterface).IsAssignableFrom(type);

    private static Func<Type, IFilterCriterion<T>> CreateInstance<T, TParams>(TParams parameters) =>
        criterion => Activator.CreateInstance(criterion, parameters) as IFilterCriterion<T>
                     ?? throw new Exception("Error when creating IFilterCriterion");
}
