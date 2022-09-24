using MassTransit;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.Social.DataAccess;

namespace TeamworkSystem.Social.API.Consumers;


public class UserChangedEventConsumer : IConsumer<UserChangedEvent>
{
    private readonly SocialDbContext _dbContext;

    public UserChangedEventConsumer(SocialDbContext dbContext)
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
