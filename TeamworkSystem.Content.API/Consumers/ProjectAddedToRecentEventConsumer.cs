using MassTransit;
using TeamworkSystem.Content.Application.Interfaces;
using TeamworkSystem.Content.Domain.Entities;
using TeamworkSystem.Content.Domain.Enums;
using TeamworkSystem.EventBus.Messages.RecentEvents;

namespace TeamworkSystem.Content.API.Consumers;

public class ProjectAddedToRecentEventConsumer : IConsumer<ProjectAddedToRecentEvent>
{
    private readonly IUnitOfWork _unitOfWork;

    public ProjectAddedToRecentEventConsumer(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task Consume(ConsumeContext<ProjectAddedToRecentEvent> context)
    {
        await _unitOfWork.RecentRequestRepository.InsertAsync(new RecentRequest
        {
            UserProfileId = context.Message.UserId,
            RequestedEntityId = context.Message.ProjectId,
            RecentRequestEntityType = RecentRequestEntityType.Project,
            RequestedAt = DateTime.Now
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
