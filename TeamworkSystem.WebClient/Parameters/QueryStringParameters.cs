namespace TeamworkSystem.WebClient.Parameters;

public class QueryStringParameters
{
    protected const int MaxPageSize = 50;

    protected int pageSize = 10;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => pageSize;

        set => pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}
