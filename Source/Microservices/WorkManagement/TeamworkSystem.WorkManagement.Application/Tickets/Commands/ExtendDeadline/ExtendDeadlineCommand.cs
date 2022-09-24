using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Tickets.Commands.ExtendDeadline;

public class ExtendDeadlineCommand : IRequest
{
    public Guid Id { get; set; }
    public DateTime Deadline { get; set; }
}
