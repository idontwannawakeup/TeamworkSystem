using TeamworkSystem.Social.DataAccess.Interfaces;
using TeamworkSystem.Social.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.Social.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    protected readonly TeamworkSystemSocialDbContext DatabaseContext;

    public UnitOfWork(
        TeamworkSystemSocialDbContext databaseContext,
        IRatingsRepository ratingsRepository)
    {
        DatabaseContext = databaseContext;
        RatingsRepository = ratingsRepository;
    }

    public IRatingsRepository RatingsRepository { get; }

    public async Task SaveChangesAsync() => await DatabaseContext.SaveChangesAsync();
}
