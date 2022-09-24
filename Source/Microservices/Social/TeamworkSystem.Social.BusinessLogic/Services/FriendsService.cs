using AutoMapper;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Requests;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Responses;
using TeamworkSystem.Social.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Social.DataAccess.Common.Parameters;
using TeamworkSystem.Social.DataAccess.Data.Entities;
using TeamworkSystem.Social.DataAccess.Interfaces.Data;

namespace TeamworkSystem.Social.BusinessLogic.Services;

public class FriendsService : IFriendsService
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
