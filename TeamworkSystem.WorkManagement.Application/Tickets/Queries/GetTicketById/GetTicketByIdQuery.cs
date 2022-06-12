using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Responses;

namespace TeamworkSystem.WorkManagement.Application.Tickets.Queries.GetTicketById;

public class GetTicketByIdQuery : IRequest<TicketResponse>
{
    public Guid Id { get; set; }
}
