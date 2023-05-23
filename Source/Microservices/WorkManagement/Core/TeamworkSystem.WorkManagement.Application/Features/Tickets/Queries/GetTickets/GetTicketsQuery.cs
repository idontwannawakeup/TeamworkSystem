using MediatR;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Features.Tickets.Queries.GetTickets;

public class GetTicketsQuery : IRequest<PagedList<TicketResponse>>
{
    public TicketsParameters Parameters { get; set; } = default!;
}
