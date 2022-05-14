using AutoMapper;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.BusinessLogic.DTO.Requests;
using TeamworkSystem.Social.BusinessLogic.DTO.Responses;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Interfaces;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.BusinessLogic.Services;

public class FriendsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FriendsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<UserResponse>> GetAsync(Guid userId, FriendsParameters parameters)
    {
        var friends = await _unitOfWork.FriendsRepository.GetAsync(userId, parameters);
        return friends.Map(_mapper.Map<UserProfile, UserResponse>);
    }

    public async Task AddToFriendsAsync(FriendsRequest request)
    {
        await _unitOfWork.FriendsRepository.AddToFriendsAsync(request.FirstId, request.SecondId);
    }

    public async Task DeleteFromFriendsAsync(FriendsRequest request)
    {
        await _unitOfWork.FriendsRepository.DeleteFromFriendsAsync(request.FirstId, request.SecondId);
    }
}
