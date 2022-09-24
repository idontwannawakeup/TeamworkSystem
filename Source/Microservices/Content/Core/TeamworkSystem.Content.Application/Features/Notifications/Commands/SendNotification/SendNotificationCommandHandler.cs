using AutoMapper;
using MediatR;
using TeamworkSystem.Content.Application.Interfaces;
using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Application.Features.Notifications.Commands.SendNotification;

public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SendNotificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(
        SendNotificationCommand request,
        CancellationToken cancellationToken)
    {
        // ReSharper disable once UnusedVariable
        var notification = await _unitOfWork.NotificationRepository.InsertAsync(
            _mapper.Map<Notification>(request));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        // TODO: implement notification send with gRPC
        return Unit.Value;
    }
}
