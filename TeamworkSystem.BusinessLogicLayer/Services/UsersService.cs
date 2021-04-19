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

        public async Task SignUpAsync(UserSignUpRequest userSignUp)
        {
            User user = this.mapper.Map<UserSignUpRequest, User>(userSignUp);
            IdentityResult signUpResult = await this.userManager.CreateAsync(user, userSignUp.Password);

            if (!signUpResult.Succeeded)
            {
                string errors = string.Join("\n",
                    signUpResult.Errors.Select(
                        error => error.Description));

                throw new ArgumentException(errors);
            }

            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserResponse>> GetAsync()
        {
            List<User> users = await this.userManager.Users.ToListAsync();
            return users?.Select(
                this.mapper.Map<User, UserResponse>);
        }

        public async Task<PagedList<UserResponse>> GetAsync(
            UsersParameters parameters)
        {
            PagedList<User> users = await this.userManager.GetAsync(parameters);
            return users?.Map(
                this.mapper.Map<User, UserResponse>);
        }

        public async Task<UserResponse> GetByIdAsync(string id)
        {
            User user = await this.userManager.GetCompleteEntityAsync(id);
            return this.mapper.Map<User, UserResponse>(user);
        }

        public async Task<PagedList<UserResponse>> GetFriendsAsync(
            string id,
            UsersParameters parameters)
        {
            PagedList<User> friends = await this.userManager.GetFriendsAsync(id, parameters);
            return friends?.Map(
                this.mapper.Map<User, UserResponse>);
        }

        public async Task DeleteAsync(string id)
        {
            User user = await this.userManager.GetByIdAsync(id);
            await this.unitOfWork.UserManager.DeleteAsync(user);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task AddFriendAsync(FriendsRequest friendsRequest)
        {
            await this.MakeActionWithFriends(friendsRequest, (firstUser, secondUser) =>
            {
                firstUser.Friends.Add(secondUser);
                secondUser.Friends.Add(firstUser);
            });
        }

        public async Task DeleteFriendAsync(FriendsRequest friendsRequest)
        {
            await this.MakeActionWithFriends(friendsRequest, (firstUser, secondUser) =>
            {
                firstUser.Friends.Remove(secondUser);
                secondUser.Friends.Remove(firstUser);
            });
        }

        private async Task MakeActionWithFriends(
            FriendsRequest friendsRequest,
            Action<User, User> action)
        {
            User firstUser = await this.userManager.GetCompleteEntityAsync(friendsRequest.FirstId);
            User secondUser = await this.userManager.GetCompleteEntityAsync(friendsRequest.SecondId);

            action?.Invoke(firstUser, secondUser);
            await this.userManager.UpdateAsync(firstUser);
            await this.userManager.UpdateAsync(secondUser);

            await this.unitOfWork.SaveChangesAsync();
        }

        public UsersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = this.unitOfWork.UserManager;
        }
    }
}
