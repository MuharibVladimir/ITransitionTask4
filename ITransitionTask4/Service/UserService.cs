using AutoMapper;
using ITransitionTask4.Contracts;
using ITransitionTask4.DataTransferObjects;
using ITransitionTask4.Entities.Models;
using ITransitionTask4.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ITransitionTask4.Service
{
    internal sealed class UserService: IUserService 
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;
        private readonly UserManager<User> _userManager;
        private User? _user;
        public UserService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _repository = repository;
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges)
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersDto;
       }

        public async Task DeleteUsersAsync(IEnumerable<string> userIds)
        {
            foreach (var userId in userIds)
            {
                var userEntity = await _userManager.FindByIdAsync(userId);
                await _userManager.DeleteAsync(userEntity);
            }

            await _repository.SaveAsync();
        }

        public async Task BlockUsersAsync(IEnumerable<string> userIds)
        {
            foreach (var userId in userIds)
            {
                var userEntity = await _userManager.FindByIdAsync(userId);
                userEntity.Status = "Blocked";
            }

            await _repository.SaveAsync();
        }

        public async Task UnBlockUsersAsync(IEnumerable<string> userIds)
        {
            foreach (var userId in userIds)
            {
                var userEntity = await _userManager.FindByIdAsync(userId);
                userEntity.Status = "Active";
            }

            await _repository.SaveAsync();
        }
    }
}
