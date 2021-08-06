using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class RatingsRepository : GenericRepository<Rating>, IRatingsRepository
    {
        public RatingsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }

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
                                             .Include(rating => rating.To);

            SearchByRatedUserId(ref source, parameters.RatedUserId);
            return await PagedList<Rating>.ToPagedListAsync(source,
                                                            parameters.PageNumber,
                                                            parameters.PageSize);
        }

        public async Task<IEnumerable<Rating>> GetRatingsFromUserAsync(string userId)
        {
            return await Table.Where(rating => rating.FromId == userId)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetRatingsForUserAsync(string userId)
        {
            return await Table.Where(rating => rating.ToId == userId)
                              .ToListAsync();
        }

        private static void SearchByRatedUserId(ref IQueryable<Rating> source, string ratedUserId)
        {
            if (string.IsNullOrWhiteSpace(ratedUserId))
            {
                return;
            }

            source = source.Where(rating => rating.ToId == ratedUserId);
        }
    }
}
