namespace TeamworkSystem.DataAccessLayer.Parameters
{
    public class PaginationParameters
    {
        protected const int MaxPageSize = 50;

        protected int pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => this.pageSize;

            set => this.pageSize = (value > MaxPageSize)
                ? MaxPageSize
                : value;
        }
    }
}
