namespace TeamworkSystem.WebClient.Parameters;

public class ParametersStringFactory
{
    public static string GenerateParametersString(ProjectsParameters parameters) =>
        $"{GetPaginationParameters(parameters)}"
        + $"&{nameof(parameters.TeamId)}={parameters.TeamId}"
        + $"&{nameof(parameters.TeamMemberId)}={parameters.TeamMemberId}"
        + $"&{nameof(parameters.Title)}={parameters.Title}";

    public static string GenerateParametersString(RatingsParameters parameters) =>
        $"{GetPaginationParameters(parameters)}"
        + $"&{nameof(parameters.RatedUserId)}={parameters.RatedUserId}";

    public static string GenerateParametersString(TeamsParameters parameters) =>
        $"{GetPaginationParameters(parameters)}"
        + $"&{nameof(parameters.UserId)}={parameters.UserId}"
        + $"&{nameof(parameters.Name)}={parameters.Name}";

    public static string GenerateParametersString(TicketsParameters parameters) =>
        $"{GetPaginationParameters(parameters)}"
        + $"&{nameof(parameters.ProjectId)}={parameters.ProjectId}"
        + $"&{nameof(parameters.ExecutorId)}={parameters.ExecutorId}"
        + $"&{nameof(parameters.Title)}={parameters.Title}"
        + $"&{nameof(parameters.Status)}={parameters.Status}";

    public static string GenerateParametersString(UsersParameters parameters) =>
        $"{GetPaginationParameters(parameters)}"
        + $"&{nameof(parameters.TeamId)}={parameters.TeamId}"
        + $"&{nameof(parameters.LastName)}={parameters.LastName}";

    private static string GetPaginationParameters(QueryStringParameters parameters) =>
        $"?PageNumber={parameters.PageNumber}&PageSize={parameters.PageSize}";
}
