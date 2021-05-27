namespace TeamworkSystem.WebClient.ViewModels
{
    public class PaginationHeaderViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalEntitiesCount { get; set; }

        public bool HasPrevious { get; set; }

        public bool HasNext { get; set; }
    }
}
