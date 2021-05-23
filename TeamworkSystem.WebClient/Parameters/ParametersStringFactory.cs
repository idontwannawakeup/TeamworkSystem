namespace TeamworkSystem.WebClient.Parameters
{
    public class ParametersStringFactory
    {
        public static string GenerateParametersString(TeamsParameters parameters) =>
            $"{GetPaginationParameters(parameters)}"
            + $"&{nameof(parameters.UserId)}={parameters.UserId}"
            + $"&{nameof(parameters.Name)}={parameters.Name}";

        public static string GenerateParametersString(ProjectsParameters parameters) =>
            $"{GetPaginationParameters(parameters)}"
            + $"&{nameof(parameters.TeamId)}={parameters.TeamId}"
            + $"&{nameof(parameters.TeamMemberId)}={parameters.TeamMemberId}";

        public static string GenerateParametersString(TicketsParameters parameters) =>
            $"{GetPaginationParameters(parameters)}"
            + $"&{nameof(parameters.ProjectId)}={parameters.ProjectId}"
            + $"&{nameof(parameters.ExecutorId)}={parameters.ExecutorId}";

        public static string GenerateParametersString(RatingsParameters parameters) =>
            $"{GetPaginationParameters(parameters)}"
            + $"&{nameof(parameters.RatedUserId)}={parameters.RatedUserId}";

        public static string GenerateParametersString(UsersParameters parameters) =>
            $"{GetPaginationParameters(parameters)}"
            + $"&{nameof(parameters.TeamId)}={parameters.TeamId}";

        private static string GetPaginationParameters(QueryStringParameters parameters) =>
            $"?PageNumber={parameters.PageNumber}&PageSize={parameters.PageSize}";
    }
}
