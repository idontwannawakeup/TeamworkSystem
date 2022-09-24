using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Extensions;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories;

public class RatingsRepository : GenericRepository<Rating>, IRatingsRepository
{
    private readonly IFilterFactory<Rating> _filter;

    public RatingsRepository(TeamworkSystemContext databaseContext, IFilterFactory<Rating> filter) :
        base(databaseContext) => _filter = filter;

    public override async Task<Rating> GetCompleteEntityAsync(int id)
    {
        var rating = await Table.Include(rating => rating.From)
                                .Include(rating => rating.To)
                                .SingleOrDefaultAsync(rating => rating.Id == id);

        return rating ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }

    public async Task<PagedList<Rating>> GetAsync(RatingsParameters parameters)
    {
        IQueryable<Rating> source = Table.Include(rating => rating.From)
                                         .Include(rating => rating.To)
                                         .FilterWith(_filter.Get(parameters));

        return await PagedList<Rating>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<IEnumerable<Rating>> GetRatingsFromUserAsync(string userId) =>
        await Table.Where(rating => rating.FromId == userId).ToListAsync();

    public async Task<IEnumerable<Rating>> GetRatingsForUserAsync(string userId) =>
        await Table.Where(rating => rating.ToId == userId).ToListAsync();
}
