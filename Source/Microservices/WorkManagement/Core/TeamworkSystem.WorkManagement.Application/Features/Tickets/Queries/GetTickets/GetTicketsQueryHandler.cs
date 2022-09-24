using AutoMapper;
using MediatR;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Features.Tickets.Queries.GetTickets;

public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, PagedList<TicketResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTicketsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<TicketResponse>> Handle(
        GetTicketsQuery request,
        CancellationToken cancellationToken)
    {
        var tickets = await _unitOfWork.TicketsRepository.GetAsync(request.Parameters);
        return tickets.Map(_mapper.Map<Ticket, TicketResponse>);
    }
}
