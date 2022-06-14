using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using TeamworkSystem.Content.Application.Interfaces;
using TeamworkSystem.Content.Domain.Entities;
using TeamworkSystem.Content.Domain.Enums;
using TeamworkSystem.EventBus.Messages.RecentEvents;

namespace TeamworkSystem.Content.API.Consumers;

public class TicketAddedToRecentEventConsumer : IConsumer<TicketAddedToRecentEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDistributedCache _cache;

    public TicketAddedToRecentEventConsumer(IUnitOfWork unitOfWork, IDistributedCache cache)
    {
        _unitOfWork = unitOfWork;
        _cache = cache;
    }

    public async Task Consume(ConsumeContext<TicketAddedToRecentEvent> context)
    {
        await _unitOfWork.RecentRequestRepository.InsertAsync(new RecentRequest
        {
            UserProfileId = context.Message.UserId,
            RequestedEntityId = context.Message.TicketId,
            RecentRequestEntityType = RecentRequestEntityType.Ticket,
            RequestedAt = DateTime.Now
        });

        await _unitOfWork.SaveChangesAsync();
        await _cache.RemoveAsync($"{context.Message.UserId}-{RecentRequestEntityType.Ticket}");
    }
}
