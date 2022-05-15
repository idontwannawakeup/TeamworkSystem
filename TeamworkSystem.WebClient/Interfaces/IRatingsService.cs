using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces;

public interface IRatingsService
{
    Task<IEnumerable<RatingViewModel>> GetAsync(RatingsParameters parameters);

    Task<(IEnumerable<RatingViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
        RatingsParameters parameters);

    Task<IEnumerable<RatingViewModel>> GetByRatedUserId(Guid userId);

    Task<RatingViewModel> GetByIdAsync(Guid id);

    Task CreateAsync(RatingViewModel viewModel);

    Task UpdateAsync(RatingViewModel viewModel);

    Task DeleteAsync(Guid id);
}
