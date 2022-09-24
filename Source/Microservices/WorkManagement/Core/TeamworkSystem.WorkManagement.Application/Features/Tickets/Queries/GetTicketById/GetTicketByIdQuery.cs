using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;

namespace TeamworkSystem.WorkManagement.Application.Features.Tickets.Queries.GetTicketById;

public class GetTicketByIdQuery : IRequest<TicketResponse>
{
    public Guid Id { get; set; }
}
