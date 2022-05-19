using MediatR;
using TeamworkSystem.WorkManagement.Application.Interfaces;

namespace TeamworkSystem.WorkManagement.Application.Tickets.Commands.UpdateTicket;

public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.TicketsRepository.GetByIdAsync(request.Id);
        ticket.ProjectId = request.ProjectId;
        ticket.ExecutorId = request.ExecutorId;
        ticket.Title = request.Title;
        ticket.Type = request.Type;
        ticket.Description = request.Description;
        ticket.Status = request.Status;
        ticket.Priority = request.Priority;
        ticket.Deadline = request.Deadline;
        await _unitOfWork.TicketsRepository.UpdateAsync(ticket);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
