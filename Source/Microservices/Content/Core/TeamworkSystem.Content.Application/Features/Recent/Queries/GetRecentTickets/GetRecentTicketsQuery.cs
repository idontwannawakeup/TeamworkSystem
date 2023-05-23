﻿using MediatR;
using TeamworkSystem.Content.Application.Common.Models.Responses;

namespace TeamworkSystem.Content.Application.Features.Recent.Queries.GetRecentTickets;

public class GetRecentTicketsQuery : IRequest<IEnumerable<TicketResponse>>
{
    public Guid UserId { get; set; }
}
