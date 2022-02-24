using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Shared.Extensions;

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
