namespace TeamworkSystem.DataAccessLayer.Interfaces.Filters;

public interface IFilterFactory
{
    IFilter<T> Get<T, TParams>(TParams parameters) where TParams : IFilterParameters<T>;
}
