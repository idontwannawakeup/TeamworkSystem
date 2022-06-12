using MassTransit;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.WorkManagement.Persistence;

namespace TeamworkSystem.WorkManagement.API.Consumers;

public class UserChangedEventConsumer : IConsumer<UserChangedEvent>
{
    private readonly WorkManagementDbContext _dbContext;

    public UserChangedEventConsumer(WorkManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<UserChangedEvent> context)
    {
        var userProfile = await _dbContext.UserProfiles.FindAsync(context.Message.Id);
        userProfile!.FirstName = context.Message.FirstName;
        userProfile.LastName = context.Message.LastName;
        userProfile.Profession = context.Message.Profession;
        userProfile.Specialization = context.Message.Specialization;
        _dbContext.UserProfiles.Update(userProfile);
        await _dbContext.SaveChangesAsync();
    }
}
