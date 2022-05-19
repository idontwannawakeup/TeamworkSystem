using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Tickets.Commands.DeleteTicket;

public class DeleteTicketCommand : IRequest
{
    public Guid Id { get; set; }
}
