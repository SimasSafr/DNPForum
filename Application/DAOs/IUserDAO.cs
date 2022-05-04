using Entities.Models;

namespace Application.Contracts;

public interface IUserDAO
{
    public Task<User> CreateUserAsync(User user);

    public Task<User?> GetUserByUsernameAsync(string username);
    public Task<ICollection<User>> GetAllUsersAsync();
}