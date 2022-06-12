using AutoMapper;
using MassTransit;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.Social.DataAccess;
using TeamworkSystem.Social.DataAccess.Entities;

namespace TeamworkSystem.Social.API.Consumers;

public class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
{
    private readonly SocialDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserCreatedEventConsumer(SocialDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        var userProfile = _mapper.Map<UserProfile>(context.Message);
        _dbContext.UserProfiles.Add(userProfile);
        await _dbContext.SaveChangesAsync();
    }
}
