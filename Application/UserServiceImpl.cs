using Application.Contracts;
using Contracts.Services;
using Entities.Models;

namespace Application;

public class UserServiceImpl : IUserService
{
    private IUserDAO userDao;
    
    public UserServiceImpl(IUserDAO userDao) {
        this.userDao = userDao;
    }
    public async Task<User> AddUserAsync(User user)
    {
        return await userDao.CreateUserAsync(user);
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await userDao.GetUserByUsernameAsync(username);
    }
}