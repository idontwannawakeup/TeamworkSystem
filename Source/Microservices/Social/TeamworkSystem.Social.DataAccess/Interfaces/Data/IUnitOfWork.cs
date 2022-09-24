using TeamworkSystem.Social.DataAccess.Interfaces.Data.Repositories;

namespace TeamworkSystem.Social.DataAccess.Interfaces.Data;

public interface IUnitOfWork
{
    IRatingsRepository RatingsRepository { get; }
    IFriendsRepository FriendsRepository { get; }
}
