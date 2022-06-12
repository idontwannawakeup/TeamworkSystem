using MassTransit;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.WorkManagement.Persistence;

namespace TeamworkSystem.WorkManagement.API.Consumers;

public class UserAvatarChangedEventConsumer : IConsumer<UserAvatarChangedEvent>
{
    private readonly WorkManagementDbContext _dbContext;

    public UserAvatarChangedEventConsumer(WorkManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<UserAvatarChangedEvent> context)
    {
        var userProfile = await _dbContext.UserProfiles.FindAsync(context.Message.UserId);
        userProfile!.Avatar = context.Message.Avatar;
        _dbContext.UserProfiles.Update(userProfile);
        await _dbContext.SaveChangesAsync();
    }
}
