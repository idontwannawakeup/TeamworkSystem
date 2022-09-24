namespace TeamworkSystem.Shared.Interfaces.Filters;

public interface IFilterFactory<T>
{
    IFilter<T> Get<TParams>(TParams parameters) where TParams : IFilterParameters<T>;
}
