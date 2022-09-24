using TeamworkSystem.Social.DataAccess.Interfaces.Data;
using TeamworkSystem.Social.DataAccess.Interfaces.Data.Repositories;

namespace TeamworkSystem.Social.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IRatingsRepository ratingsRepository, IFriendsRepository friendsRepository)
    {
        RatingsRepository = ratingsRepository;
        FriendsRepository = friendsRepository;
    }

    public IRatingsRepository RatingsRepository { get; }
    public IFriendsRepository FriendsRepository { get; }
}
