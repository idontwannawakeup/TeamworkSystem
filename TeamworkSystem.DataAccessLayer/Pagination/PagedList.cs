using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeamworkSystem.DataAccessLayer.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public int TotalEntitiesCount { get; private set; }

        public bool HasPrevious => this.CurrentPage > 1;

        public bool HasNext => this.CurrentPage < this.TotalPages;

        public object Metadata => new
        {
            this.CurrentPage,
            this.TotalPages,
            this.PageSize,
            this.TotalEntitiesCount,
            this.HasPrevious,
            this.HasNext
        };

        public PagedList<TOut> Map<TOut>(Func<T, TOut> selectExpression)
        {
            IEnumerable<TOut> mappedItems = this.Select(selectExpression);
            return new(
                mappedItems,
                this.TotalEntitiesCount,
                this.CurrentPage,
                this.PageSize);
        }

        public async static Task<PagedList<T>> ToPagedListAsync(
            IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            int totalEntitiesCount = source.Count();

            IEnumerable<T> items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new(items, totalEntitiesCount, pageNumber, pageSize);
        }

        public PagedList(
            IEnumerable<T> items,
            int totalEntitiesCount,
            int pageNumber,
            int pageSize)
        {
            this.CurrentPage = pageNumber;
            this.PageSize = pageSize;
            this.TotalEntitiesCount = totalEntitiesCount;
            this.TotalPages = (int) Math.Ceiling(totalEntitiesCount / (double) pageSize);

            this.AddRange(items);
        }
    }
}
