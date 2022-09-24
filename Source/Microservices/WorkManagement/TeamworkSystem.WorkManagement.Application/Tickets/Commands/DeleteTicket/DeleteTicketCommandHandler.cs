using MediatR;
using TeamworkSystem.WorkManagement.Application.Interfaces;

namespace TeamworkSystem.WorkManagement.Application.Tickets.Commands.DeleteTicket;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTicketCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.TicketsRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
