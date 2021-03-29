using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public async Task SignUpAsync(UserSignUpDTO userSignUpDTO)
        {
            User user = this.mapper.Map<UserSignUpDTO, User>(userSignUpDTO);
            await this.unitOfWork.UserManager.CreateAsync(user, userSignUpDTO.Password);
        }

        public async Task<IEnumerable<UserProfileDTO>> GetAllProfilesAsync()
        {
            List<User> users = await this.unitOfWork.UserManager.Users.ToListAsync();
            return users.Select(this.mapper.Map<User, UserProfileDTO>);
        }

        public async Task<UserProfileDTO> GetProfileByIdAsync(string id)
        {
            User user = await this.unitOfWork.UserManager.FindByIdAsync(id);
            return this.mapper.Map<User, UserProfileDTO>(user);
        }

        public async Task DeleteAsync(string id)
        {
            User user = await this.unitOfWork.UserManager.FindByIdAsync(id);
            await this.unitOfWork.UserManager.DeleteAsync(user);
        }

        public async Task AddFriend(string id, string friendId)
        {
            User user = await this.unitOfWork.UserManager.FindByIdAsync(id);
            User friend = await this.unitOfWork.UserManager.FindByIdAsync(friendId);
            await this.unitOfWork.UserManager.UpdateAsync(user);
            await this.unitOfWork.UserManager.UpdateAsync(friend);
            user.Friends.Add(friend);
            friend.Friends.Add(user);
        }

        public async Task DeleteFriend(string id, string friendId)
        {
            User user = await this.unitOfWork.UserManager.FindByIdAsync(id);
            User friend = await this.unitOfWork.UserManager.FindByIdAsync(friendId);
            await this.unitOfWork.UserManager.UpdateAsync(user);
            await this.unitOfWork.UserManager.UpdateAsync(friend);
            user.Friends.Remove(friend);
            friend.Friends.Remove(user);
        }

        public UsersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
