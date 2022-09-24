using AutoMapper;
using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;
using TeamworkSystem.Content.Application.Interfaces;

namespace TeamworkSystem.Content.Application.Features.Notifications.Queries.GetTopRecentNotifications;

public class GetTopRecentNotificationsQueryHandler
    : IRequestHandler<GetTopRecentNotificationsQuery, IEnumerable<NotificationResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTopRecentNotificationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NotificationResponse>> Handle(
        GetTopRecentNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        var notifications = await _unitOfWork.NotificationRepository.GetTopRecentAsync(request.UserId);
        return _mapper.Map<IEnumerable<NotificationResponse>>(notifications);
    }
}
