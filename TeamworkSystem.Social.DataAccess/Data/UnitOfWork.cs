using TeamworkSystem.Social.DataAccess.Interfaces;
using TeamworkSystem.Social.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.Social.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IRatingsRepository ratingsRepository)
    {
        RatingsRepository = ratingsRepository;
    }

    public IRatingsRepository RatingsRepository { get; }
}
