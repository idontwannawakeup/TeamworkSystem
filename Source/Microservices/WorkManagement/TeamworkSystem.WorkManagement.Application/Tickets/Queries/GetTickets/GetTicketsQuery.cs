using MediatR;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Responses;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Tickets.Queries.GetTickets;

public class GetTicketsQuery : IRequest<PagedList<TicketResponse>>
{
    public TicketsParameters Parameters { get; set; } = default!;
}
