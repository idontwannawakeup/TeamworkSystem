using TeamworkSystem.Social.DataAccess.Data.Repositories;
using TeamworkSystem.Social.DataAccess.Interfaces;
using TeamworkSystem.Social.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.Social.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IRatingsRepository ratingsRepository, FriendsRepository friendsRepository)
    {
        RatingsRepository = ratingsRepository;
        FriendsRepository = friendsRepository;
    }

    public IRatingsRepository RatingsRepository { get; }
    public FriendsRepository FriendsRepository { get; }
}
