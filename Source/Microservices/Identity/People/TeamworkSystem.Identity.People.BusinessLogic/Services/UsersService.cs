﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.People.BusinessLogic.Common.Models.Requests;
using TeamworkSystem.Identity.People.BusinessLogic.Common.Models.Responses;
using TeamworkSystem.Identity.People.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Identity.Persistence.People.Common.Parameters;
using TeamworkSystem.Identity.Persistence.People.Data.Entities;
using TeamworkSystem.Identity.Persistence.People.Extensions;
using TeamworkSystem.Identity.Persistence.People.Interfaces.Data;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Identity.People.BusinessLogic.Services;

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

    public async Task<UserResponse> GetByIdAsync(Guid id)
    {
        var user = await _userManager.GetCompleteEntityAsync(id);
        return _mapper.Map<User, UserResponse>(user);
    }

    public async Task<UserResponse> UpdateAsync(UserRequest request)
    {
        var user = await _userManager.GetByIdAsync(request.Id);
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Profession = request.Profession;
        user.Specialization = request.Specialization;
        await _userManager.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<UserResponse>(user);
    }

    public async Task<string> SetAvatarForUserAsync(UserAvatarRequest request)
    {
        var user = await _userManager.GetByIdAsync(request.UserId);
        user.Avatar = await _photosService.SavePhotoAsync(request.Avatar);
        await _userManager.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
        return user.Avatar;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _userManager.GetByIdAsync(id);
        await _unitOfWork.UserManager.DeleteAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }
}
