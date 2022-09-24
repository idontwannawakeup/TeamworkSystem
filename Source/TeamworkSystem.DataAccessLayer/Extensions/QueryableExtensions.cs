using TeamworkSystem.DataAccessLayer.Interfaces.Filters;

namespace TeamworkSystem.DataAccessLayer.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> FilterWith<T>(
        this IQueryable<T> items,
        IFilter<T> filter) =>
        filter.ApplyFilters(items);

    public static IQueryable<T> FilterBy<T>(
        this IQueryable<T> items,
        IFilterCriterion<T> criterion) =>
        criterion.Condition ? items.Where(criterion.Expression) : items;
}
