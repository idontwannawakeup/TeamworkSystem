using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;
using TeamworkSystem.WebClient.ViewModels.DapperViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface IRatingsService
    {
        Task<IEnumerable<RatingViewModel>> GetAsync(RatingsParameters parameters);

        Task<(IEnumerable<RatingViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            RatingsParameters parameters);

        Task<IEnumerable<RatingViewModel>> GetByRatedUserId(string userId);

        Task<RatingViewModel> GetByIdAsync(int id);

        Task CreateAsync(RatingViewModel viewModel);

        Task UpdateAsync(RatingViewModel viewModel);

        Task DeleteAsync(int id);

        Task<RatingAverageScoresViewModel> GetAverageScoresByUserIdAsync(string userId);
    }
}
