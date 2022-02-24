namespace TeamworkSystem.DataAccessLayer.Interfaces.Filters;

public interface IFilterFactory<T>
{
    IFilter<T> Get<TParams>(TParams parameters) where TParams : IFilterParameters<T>;
}
