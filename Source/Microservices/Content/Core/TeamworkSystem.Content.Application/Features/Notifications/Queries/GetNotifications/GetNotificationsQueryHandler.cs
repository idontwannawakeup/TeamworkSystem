using AutoMapper;
using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;
using TeamworkSystem.Content.Application.Interfaces;

namespace TeamworkSystem.Content.Application.Features.Notifications.Queries.GetNotifications;

public class GetNotificationsQueryHandler
    : IRequestHandler<GetNotificationsQuery, IEnumerable<NotificationResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetNotificationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NotificationResponse>> Handle(
        GetNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        var notifications = await _unitOfWork.NotificationRepository.GetAsync(request.UserId);
        return _mapper.Map<IEnumerable<NotificationResponse>>(notifications);
    }
}
