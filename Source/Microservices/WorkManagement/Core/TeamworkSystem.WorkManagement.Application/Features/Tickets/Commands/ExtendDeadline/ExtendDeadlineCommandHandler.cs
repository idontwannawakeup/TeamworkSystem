using MediatR;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data;

namespace TeamworkSystem.WorkManagement.Application.Features.Tickets.Commands.ExtendDeadline;

public class ExtendDeadlineCommandHandler : IRequestHandler<ExtendDeadlineCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public ExtendDeadlineCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(
        ExtendDeadlineCommand request,
        CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.TicketsRepository.GetByIdAsync(request.Id);
        if (ticket.Deadline > request.Deadline)
        {
            throw new Exception("New date of deadline is sooner than current.");
        }

        ticket.Deadline = request.Deadline;
        await _unitOfWork.TicketsRepository.UpdateAsync(ticket);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
