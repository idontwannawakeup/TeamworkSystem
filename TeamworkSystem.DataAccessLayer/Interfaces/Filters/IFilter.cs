namespace TeamworkSystem.DataAccessLayer.Interfaces.Filters;

public interface IFilter<T>
{
    IQueryable<T> ApplyFilters(IQueryable<T> items);
}
