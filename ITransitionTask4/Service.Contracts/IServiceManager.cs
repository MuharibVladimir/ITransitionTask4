using Microsoft.AspNetCore.Authentication;

namespace ITransitionTask4.Service.Contracts
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
        IUserService UserService { get; }
    }
}
