namespace TeamworkSystem.Core.BusinessLogic.DTO.Requests;

public class TicketWithExtendedDeadlineRequest
{
    public Guid Id { get; set; }

    public DateTime Deadline { get; set; }
}
