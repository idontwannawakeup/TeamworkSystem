using AutoMapper;
using TeamworkSystem.Social.BusinessLogic.DTO.Responses;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Interfaces;

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

    public async Task<IEnumerable<UserResponse>> GetAsync(Guid userId)
    {
        var friends = await _unitOfWork.FriendsRepository.GetAsync(userId);
        return friends.Select(_mapper.Map<UserProfile, UserResponse>);
    }
}
