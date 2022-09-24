using AutoMapper;
using MassTransit;
using TeamworkSystem.EventBus.Messages;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Persistence;

namespace TeamworkSystem.WorkManagement.API.Consumers;

public class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
{
    private readonly WorkManagementDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserCreatedEventConsumer(WorkManagementDbContext dbContext, IMapper mapper)
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
