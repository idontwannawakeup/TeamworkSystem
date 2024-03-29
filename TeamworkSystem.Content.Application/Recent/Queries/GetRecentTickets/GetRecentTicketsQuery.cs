﻿using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;

namespace TeamworkSystem.Content.Application.Recent.Queries.GetRecentTickets;

public class GetRecentTicketsQuery : IRequest<IEnumerable<TicketResponse>>
{
    public Guid UserId { get; set; }
}
