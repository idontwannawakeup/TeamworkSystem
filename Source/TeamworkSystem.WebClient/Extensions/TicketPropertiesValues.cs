namespace TeamworkSystem.WebClient.Extensions;

public class TicketPropertiesValues
{
    public static List<string> Types { get; } = new()
    {
        "Epic",
        "Task",
        "Bug"
    };

    public static List<string> Statuses { get; } = new()
    {
        "Backlog",
        "Chosen For Development",
        "In Progress",
        "Done"
    };

    public static List<string> Priorities { get; } = new()
    {
        "Low",
        "Medium",
        "High"
    };
}
