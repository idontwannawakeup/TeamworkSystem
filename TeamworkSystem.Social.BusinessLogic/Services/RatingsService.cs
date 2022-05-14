using AutoMapper;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.BusinessLogic.DTO.Requests;
using TeamworkSystem.Social.BusinessLogic.DTO.Responses;
using TeamworkSystem.Social.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Interfaces;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.BusinessLogic.Services;

public class RatingsService : IRatingsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RatingsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RatingResponse>> GetAsync()
    {
        var ratings = await _unitOfWork.RatingsRepository.GetAsync();
        return ratings.Select(_mapper.Map<Rating, RatingResponse>);
    }

    public async Task<PagedList<RatingResponse>> GetAsync(RatingsParameters parameters)
    {
        var ratings = await _unitOfWork.RatingsRepository.GetAsync(parameters);
        return ratings.Map(_mapper.Map<Rating, RatingResponse>);
    }

    public async Task<RatingResponse> GetByIdAsync(Guid id)
    {
        var rating = await _unitOfWork.RatingsRepository.GetByIdAsync(id);
        return _mapper.Map<Rating, RatingResponse>(rating);
    }

    public async Task InsertAsync(RatingRequest request)
    {
        var rating = _mapper.Map<RatingRequest, Rating>(request);
        await _unitOfWork.RatingsRepository.InsertAsync(rating);
    }

    public async Task UpdateAsync(RatingRequest request)
    {
        var rating = _mapper.Map<RatingRequest, Rating>(request);
        await _unitOfWork.RatingsRepository.UpdateAsync(rating);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.RatingsRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<RatingResponse>> GetRatingProfilesFromUserAsync(Guid userId)
    {
        var ratings = await _unitOfWork.RatingsRepository.GetRatingsFromUserAsync(userId);
        return ratings.Select(_mapper.Map<Rating, RatingResponse>);
    }

    public async Task<IEnumerable<RatingResponse>> GetRatingProfilesForUserAsync(Guid userId)
    {
        var ratings = await _unitOfWork.RatingsRepository.GetRatingsForUserAsync(userId);
        return ratings.Select(_mapper.Map<Rating, RatingResponse>);
    }
}
