using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Application.Interfaces.Repositories;

public interface IRecentTicketRepository
{
    Task<IEnumerable<RecentTicket>> GetAsync(Guid userId);
    Task InsertAsync(RecentTicket recentTicket);
}
