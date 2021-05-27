using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Extensions;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly UserManager<User> userManager;

        private readonly IPhotosService photosService;

        public async Task<IEnumerable<UserResponse>> GetAsync()
        {
            var users = await userManager.Users.ToListAsync();
            return users?.Select(mapper.Map<User, UserResponse>);
        }

        public async Task<PagedList<UserResponse>> GetAsync(
            UsersParameters parameters)
        {
            var users = await userManager.GetAsync(parameters);
            return users?.Map(mapper.Map<User, UserResponse>);
        }

        public async Task<UserResponse> GetByIdAsync(string id)
        {
            var user = await userManager.GetCompleteEntityAsync(id);
            return mapper.Map<User, UserResponse>(user);
        }

        public async Task<PagedList<UserResponse>> GetFriendsAsync(
            string id,
            UsersParameters parameters)
        {
            var friends = await userManager.GetFriendsAsync(id, parameters);
            return friends?.Map(mapper.Map<User, UserResponse>);
        }

        public async Task UpdateAsync(UserRequest request)
        {
            var user = await userManager.GetByIdAsync(request.Id);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Profession = request.Profession;
            user.Specialization = request.Specialization;

            await userManager.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task SetAvatarForUserAsync(UserAvatarRequest request)
        {
            var user = await userManager.GetByIdAsync(request.UserId);
            user.Avatar = await photosService.SavePhotoAsync(request.Avatar);
            await userManager.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var user = await userManager.GetByIdAsync(id);
            await unitOfWork.UserManager.DeleteAsync(user);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task AddFriendAsync(FriendsRequest friendsRequest) =>
            await MakeActionWithFriends(friendsRequest, (firstUser, secondUser) =>
            {
                firstUser.Friends.Add(secondUser);
                secondUser.Friends.Add(firstUser);
            });

        public async Task DeleteFriendAsync(FriendsRequest friendsRequest) =>
            await MakeActionWithFriends(friendsRequest, (firstUser, secondUser) =>
            {
                firstUser.Friends.Remove(secondUser);
                secondUser.Friends.Remove(firstUser);
            });

        private async Task MakeActionWithFriends(
            FriendsRequest friendsRequest,
            Action<User, User> action)
        {
            var firstUser = await userManager.GetCompleteEntityAsync(friendsRequest.FirstId);
            var secondUser = await userManager.GetCompleteEntityAsync(friendsRequest.SecondId);

            action?.Invoke(firstUser, secondUser);
            await userManager.UpdateAsync(firstUser);
            await userManager.UpdateAsync(secondUser);

            await unitOfWork.SaveChangesAsync();
        }

        public UsersService(IUnitOfWork unitOfWork, IMapper mapper, IPhotosService photosService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.photosService = photosService;
            userManager = this.unitOfWork.UserManager;
        }
    }
}
