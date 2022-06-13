using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;

namespace TeamworkSystem.Content.Application.Recent.Queries.GetRecentTickets;

public class GetRecentTicketsQueryHandler
    : IRequestHandler<GetRecentTicketsQuery, IEnumerable<TicketResponse>>
{
    public Task<IEnumerable<TicketResponse>> Handle(
        GetRecentTicketsQuery request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(Array.Empty<TicketResponse>() as IEnumerable<TicketResponse>);
    }
}
