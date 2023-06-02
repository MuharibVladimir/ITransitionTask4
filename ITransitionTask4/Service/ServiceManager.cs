using AutoMapper;
using ITransitionTask4.Contracts;
using ITransitionTask4.Entities.Models;
using ITransitionTask4.Service.Contracts;
using Microsoft.AspNetCore.Identity;

namespace ITransitionTask4.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthService> _authService;
        private readonly Lazy<IUserService> _userService;

        public ServiceManager(IMapper mapper,
        UserManager<User> userManager,
        IRepositoryManager repository,
        IConfiguration configuration)
        {
            _authService = new Lazy<IAuthService>(() =>
                new AuthService(mapper, userManager,configuration));

            _userService = new Lazy<IUserService>(() =>
             new UserService(repository, mapper, userManager));
        }
        public IAuthService AuthService => _authService.Value;

        public IUserService UserService => _userService.Value;
    }
}
