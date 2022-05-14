using TeamworkSystem.Social.DataAccess.Data.Repositories;
using TeamworkSystem.Social.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.Social.DataAccess.Interfaces;

public interface IUnitOfWork
{
    IRatingsRepository RatingsRepository { get; }
    FriendsRepository FriendsRepository { get; }
}
