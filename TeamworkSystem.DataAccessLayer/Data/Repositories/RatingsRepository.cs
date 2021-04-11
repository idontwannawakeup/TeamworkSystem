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
    public class RatingsRepository
        : GenericRepository<Rating>, IRatingsRepository
    {
        public override async Task<Rating> GetCompleteEntityAsync(int id)
        {
            return await this.table
                .Include(rating => rating.From)
                .Include(rating => rating.To)
                .SingleOrDefaultAsync(rating => rating.Id == id)
                    ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<PagedList<Rating>> GetAsync(RatingsParameters parameters)
        {
            IQueryable<Rating> source = this.table;
            return await PagedList<Rating>.ToPagedListAsync(
                source,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public async Task<IEnumerable<Rating>> GetRatingsFromUserAsync(string userId)
        {
            return await this.table
                .Where(rating => rating.FromId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetRatingsForUserAsync(string userId)
        {
            return await this.table
                .Where(rating => rating.ToId == userId)
                .ToListAsync();
        }

        public RatingsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
