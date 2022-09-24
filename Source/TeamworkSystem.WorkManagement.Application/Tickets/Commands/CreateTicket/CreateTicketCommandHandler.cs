using AutoMapper;
using MediatR;
using TeamworkSystem.WorkManagement.Application.Interfaces;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Tickets.Commands.CreateTicket;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTicketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = _mapper.Map<CreateTicketCommand, Ticket>(request);
        await _unitOfWork.TicketsRepository.InsertAsync(ticket);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
