using ITransitionTask4.DataTransferObjects;

namespace ITransitionTask4.Service.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges);
        Task DeleteUsersAsync(IEnumerable<string> userIds);
        Task BlockUsersAsync(IEnumerable<string> userIds);
        Task UnBlockUsersAsync(IEnumerable<string> userIds);
    }
}
