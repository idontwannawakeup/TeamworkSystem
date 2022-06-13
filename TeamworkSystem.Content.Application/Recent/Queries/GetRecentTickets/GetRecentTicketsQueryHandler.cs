using AutoMapper;
using Grpc.Net.Client;
using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;
using TeamworkSystem.Content.Application.Grpc.Definitions;
using TeamworkSystem.Content.Application.Interfaces;
using TeamworkSystem.Content.Domain.Enums;

namespace TeamworkSystem.Content.Application.Recent.Queries.GetRecentTickets;

public class GetRecentTicketsQueryHandler
    : IRequestHandler<GetRecentTicketsQuery, IEnumerable<TicketResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRecentTicketsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TicketResponse>> Handle(
        GetRecentTicketsQuery request,
        CancellationToken cancellationToken)
    {
        var recent = await _unitOfWork.RecentRequestRepository.GetAsync(
            request.UserId,
            RecentRequestEntityType.Ticket);

        var grpcRequest = new GetRecentTicketsRequest
        {
            Ids = { recent.Select(r => r.RequestedEntityId.ToString()) }
        };

        using var channel = GrpcChannel.ForAddress("https://localhost:7077");
        var client = new RecentRequestsService.RecentRequestsServiceClient(channel);
        var response = await client.GetRecentTicketsAsync(
            grpcRequest,
            cancellationToken: cancellationToken);

        return _mapper.Map<IEnumerable<TicketResponse>>(response.Tickets);
    }
}
