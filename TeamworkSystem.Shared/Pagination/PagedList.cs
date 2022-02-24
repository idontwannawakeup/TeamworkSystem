using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace TeamworkSystem.Shared.Pagination;

public class PagedList<T> : List<T>
{
    public PagedList(
        IEnumerable<T> items,
        int totalEntitiesCount,
        int pageNumber,
        int pageSize)
    {
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalEntitiesCount = totalEntitiesCount;
        TotalPages = (int) Math.Ceiling(totalEntitiesCount / (double) pageSize);

        AddRange(items);
    }

    public int CurrentPage { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public int TotalEntitiesCount { get; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public object Metadata => new
    {
        CurrentPage,
        TotalPages,
        PageSize,
        TotalEntitiesCount,
        HasPrevious,
        HasNext
    };

    public PagedList<TOut> Map<TOut>(Func<T, TOut> selectExpression)
    {
        var mappedItems = this.Select(selectExpression);
        return new PagedList<TOut>(
            mappedItems,
            TotalEntitiesCount,
            CurrentPage,
            PageSize);
    }

    public string SerializeMetadata(PagedList<T> list) => JsonSerializer.Serialize(
        list.Metadata,
        new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

    public static async Task<PagedList<T>> ToPagedListAsync(
        IQueryable<T> source,
        int pageNumber,
        int pageSize)
    {
        var totalEntitiesCount = source.Count();
        IEnumerable<T> items = await source.Skip((pageNumber - 1) * pageSize)
                                           .Take(pageSize)
                                           .ToListAsync();

        return new PagedList<T>(items, totalEntitiesCount, pageNumber, pageSize);
    }
}
