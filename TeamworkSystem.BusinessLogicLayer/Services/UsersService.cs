using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Extensions;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Services;

public class UsersService : IUsersService
{
    private readonly IMapper _mapper;
    private readonly IPhotosService _photosService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public UsersService(IUnitOfWork unitOfWork, IMapper mapper, IPhotosService photosService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _photosService = photosService;
        _userManager = _unitOfWork.UserManager;
    }

    public async Task<IEnumerable<UserResponse>> GetAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        return users.Select(_mapper.Map<User, UserResponse>);
    }

    public async Task<PagedList<UserResponse>> GetAsync(UsersParameters parameters)
    {
        var users = await _userManager.GetAsync(parameters);
        return users.Map(_mapper.Map<User, UserResponse>);
    }

    public async Task<UserResponse> GetByIdAsync(string id)
    {
        var user = await _userManager.GetCompleteEntityAsync(id);
        return _mapper.Map<User, UserResponse>(user);
    }

    public async Task<PagedList<UserResponse>> GetFriendsAsync(
        string id,
        UsersParameters parameters)
    {
        var friends = await _userManager.GetFriendsAsync(id, parameters);
        return friends.Map(_mapper.Map<User, UserResponse>);
    }

    public async Task UpdateAsync(UserRequest request)
    {
        var user = await _userManager.GetByIdAsync(request.Id);
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Profession = request.Profession;
        user.Specialization = request.Specialization;
        await _userManager.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task SetAvatarForUserAsync(UserAvatarRequest request)
    {
        var user = await _userManager.GetByIdAsync(request.UserId);
        user.Avatar = await _photosService.SavePhotoAsync(request.Avatar);
        await _userManager.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var user = await _userManager.GetByIdAsync(id);
        await _unitOfWork.UserManager.DeleteAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddFriendAsync(FriendsRequest friendsRequest) =>
        await MakeActionWithFriends(friendsRequest, AddToFriends);

    public async Task DeleteFriendAsync(FriendsRequest friendsRequest) =>
        await MakeActionWithFriends(friendsRequest, DeleteFromFriends);

    private async Task MakeActionWithFriends(
        FriendsRequest friendsRequest,
        Action<User, User>? action)
    {
        var firstUser = await _userManager.GetCompleteEntityAsync(friendsRequest.FirstId);
        var secondUser = await _userManager.GetCompleteEntityAsync(friendsRequest.SecondId);

        action?.Invoke(firstUser, secondUser);
        await _userManager.UpdateAsync(firstUser);
        await _userManager.UpdateAsync(secondUser);

        await _unitOfWork.SaveChangesAsync();
    }

    private static void AddToFriends(User first, User second)
    {
        first.Friends.Add(second);
        second.Friends.Add(first);
    }

    private static void DeleteFromFriends(User first, User second)
    {
        first.Friends.Remove(first);
        second.Friends.Remove(second);
    }
}
