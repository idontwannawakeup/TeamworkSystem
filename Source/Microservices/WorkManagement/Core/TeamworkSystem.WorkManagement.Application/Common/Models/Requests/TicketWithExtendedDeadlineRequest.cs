namespace TeamworkSystem.WorkManagement.Application.Common.Models.Requests;

public class TicketWithExtendedDeadlineRequest
{
    public Guid Id { get; set; }

    public DateTime Deadline { get; set; }
}
