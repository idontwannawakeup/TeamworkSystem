using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Application.Interfaces.Repositories;

public interface IRecentTicketRepository
{
    Task<IEnumerable<RecentTicket>> GetAsync();
    Task InsertAsync(RecentTicket recentTicket);
}
