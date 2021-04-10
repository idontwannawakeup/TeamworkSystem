using System.Collections.Generic;

namespace TeamworkSystem.BusinessLogicLayer.DTO.Responses
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public int TotalEntitiesCount { get; private set; }
    }
}
