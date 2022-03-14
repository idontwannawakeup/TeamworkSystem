using AutoMapper;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.BusinessLogic.DTO.Requests;
using TeamworkSystem.Social.BusinessLogic.DTO.Responses;
using TeamworkSystem.Social.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Interfaces;
using TeamworkSystem.Social.DataAccess.Interfaces.Repositories;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.BusinessLogic.Services;

public class RatingsService : IRatingsService
{
    private readonly IMapper _mapper;
    private readonly IRatingsRepository _ratingsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RatingsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _ratingsRepository = _unitOfWork.RatingsRepository;
    }

    public async Task<IEnumerable<RatingResponse>> GetAsync()
    {
        var ratings = await _ratingsRepository.GetAsync();
        return ratings.Select(_mapper.Map<Rating, RatingResponse>);
    }

    public async Task<PagedList<RatingResponse>> GetAsync(RatingsParameters parameters)
    {
        var ratings = await _ratingsRepository.GetAsync(parameters);
        return ratings.Map(_mapper.Map<Rating, RatingResponse>);
    }

    public async Task<RatingResponse> GetByIdAsync(Guid id)
    {
        var rating = await _ratingsRepository.GetByIdAsync(id);
        return _mapper.Map<Rating, RatingResponse>(rating);
    }

    public async Task InsertAsync(RatingRequest request)
    {
        var rating = _mapper.Map<RatingRequest, Rating>(request);
        await _ratingsRepository.InsertAsync(rating);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(RatingRequest request)
    {
        var rating = _mapper.Map<RatingRequest, Rating>(request);
        await _ratingsRepository.UpdateAsync(rating);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _ratingsRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<RatingResponse>> GetRatingProfilesFromUserAsync(Guid userId)
    {
        var ratings = await _ratingsRepository.GetRatingsFromUserAsync(userId);
        return ratings.Select(_mapper.Map<Rating, RatingResponse>);
    }

    public async Task<IEnumerable<RatingResponse>> GetRatingProfilesForUserAsync(Guid userId)
    {
        var ratings = await _ratingsRepository.GetRatingsForUserAsync(userId);
        return ratings.Select(_mapper.Map<Rating, RatingResponse>);
    }
}
