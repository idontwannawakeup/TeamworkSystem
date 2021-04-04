using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces;

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
                    signUpResult.Errors.Select(error => $"{error.Description}"));

                throw new ArgumentException(errors);
            }

            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserProfileResponse>> GetAllProfilesAsync()
        {
            List<User> users = await this.userManager.Users.ToListAsync();
            return users.Select(this.mapper.Map<User, UserProfileResponse>);
        }

        public async Task<UserProfileResponse> GetProfileByIdAsync(string id)
        {
            User user = await this.userManager.FindByIdAsync(id)
                ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(id));

            return this.mapper.Map<User, UserProfileResponse>(user);
        }

        public async Task DeleteAsync(string id)
        {
            User user = await this.userManager.FindByIdAsync(id)
                ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(id));

            await this.unitOfWork.UserManager.DeleteAsync(user);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task AddFriend(FriendsRequest friendsRequest)
        {
            await this.MakeActionWithFriends(friendsRequest, (firstUser, secondUser) =>
            {
                firstUser.Friends.Add(secondUser);
                secondUser.Friends.Add(firstUser);
            });
        }

        public async Task DeleteFriend(FriendsRequest friendsRequest)
        {
            await this.MakeActionWithFriends(friendsRequest, (firstUser, secondUser) =>
            {
                firstUser.Friends.Remove(secondUser);
                secondUser.Friends.Remove(firstUser);
            });
        }

        public static string GetUserNotFoundErrorMessage(string id) =>
            $"{nameof(User)} with id {id} not found.";

        private async Task MakeActionWithFriends(FriendsRequest friendsRequest, Action<User, User> action)
        {
            User firstUser = await this.userManager.FindByIdAsync(friendsRequest.FirstId)
                ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(friendsRequest.FirstId));

            User secondUser = await this.userManager.FindByIdAsync(friendsRequest.SecondId)
                ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(friendsRequest.SecondId));

            await this.userManager.UpdateAsync(firstUser);
            await this.userManager.UpdateAsync(secondUser);
            action(firstUser, secondUser);

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
