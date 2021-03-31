using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Exceptions;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
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
                ?? throw new EntityNotFoundException(
                    $"{typeof(User).Name} with id {id} not found.");

            return this.mapper.Map<User, UserProfileResponse>(user);
        }

        public async Task DeleteAsync(string id)
        {
            User user = await this.userManager.FindByIdAsync(id);
            await this.unitOfWork.UserManager.DeleteAsync(user);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task AddFriend(FriendsRequest friendsRequest)
        {
            User firstUser = await this.userManager.FindByIdAsync(friendsRequest.FirstId)
                ?? throw new EntityNotFoundException(
                    $"{typeof(User).Name} with id {friendsRequest.FirstId} not found.");

            User secondUser = await this.userManager.FindByIdAsync(friendsRequest.SecondId);
            await this.userManager.UpdateAsync(firstUser);
            await this.userManager.UpdateAsync(secondUser);
            firstUser.Friends.Add(secondUser);
            secondUser.Friends.Add(firstUser);

            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteFriend(string id, string friendId)
        {
            User user = await this.userManager.FindByIdAsync(id);
            User friend = await this.userManager.FindByIdAsync(friendId);
            await this.userManager.UpdateAsync(user);
            await this.userManager.UpdateAsync(friend);
            user.Friends.Remove(friend);
            friend.Friends.Remove(user);

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
