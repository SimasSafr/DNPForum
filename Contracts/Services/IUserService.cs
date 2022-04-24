using Entities.Models;

namespace Contracts.Services;

public interface IUserService
{
    public Task<User> AddUserAsync(User user);
    public Task<User> GetUserByUsernameAsync(string username);
}