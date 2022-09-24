using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Content.Application.Interfaces.Repositories;
using TeamworkSystem.Content.Domain.Entities;
using TeamworkSystem.Content.Domain.Enums;

namespace TeamworkSystem.Content.Persistence.Data.Repositories;

public class RecentRequestRepository : IRecentRequestRepository
{
    private readonly ContentDbContext _context;

    public RecentRequestRepository(ContentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RecentRequest>> GetAsync(
        Guid userId,
        RecentRequestEntityType type)
    {
        return await _context.RecentRequests
                             .Where(e => e.UserProfileId == userId && e.RecentRequestEntityType == type)
                             .OrderByDescending(e => e.RequestedAt)
                             .ToListAsync();
    }

    public async Task InsertAsync(RecentRequest recentRequest)
    {
        if (_context.RecentRequests.Contains(recentRequest))
        {
            _context.RecentRequests.Update(recentRequest);
            return;
        }

        Expression<Func<RecentRequest, bool>> requestMatchPredicate =
            e => e.UserProfileId == recentRequest.UserProfileId
                 && e.RecentRequestEntityType == recentRequest.RecentRequestEntityType;

        var moreThanFiveRecentRequests = _context.RecentRequests.Count(requestMatchPredicate) > 5;
        if (moreThanFiveRecentRequests)
        {
            var requestsToDelete = await _context.RecentRequests
                                                 .Where(requestMatchPredicate)
                                                 .OrderByDescending(e => e.RequestedAt)
                                                 .Skip(4)
                                                 .ToListAsync();

            _context.RecentRequests.RemoveRange(requestsToDelete);
        }

        _context.RecentRequests.Add(recentRequest);
    }
}
