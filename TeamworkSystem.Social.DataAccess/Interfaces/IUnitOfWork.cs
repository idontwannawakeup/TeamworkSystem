using TeamworkSystem.Social.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.Social.DataAccess.Interfaces;

public interface IUnitOfWork
{
    IRatingsRepository RatingsRepository { get; }
}
