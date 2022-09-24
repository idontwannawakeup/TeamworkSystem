using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Features.Tickets.Commands.DeleteTicket;

public class DeleteTicketCommand : IRequest
{
    public Guid Id { get; set; }
}
