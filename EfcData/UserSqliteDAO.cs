using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcData;

using Application.Contracts;

public class UserSqliteDAO : IUserDAO
{
    private readonly ForumContext context;

    public UserSqliteDAO(ForumContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        EntityEntry<User> added = await context.AddAsync(user);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        //Don't like that we are turning it to a list
        List<User> users = await context.Users.ToListAsync();
        User? find = users.Find(user => user.UserName.Equals(username));
        return await Task.FromResult(find);
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        ICollection<User> users = await context.Users.ToListAsync();
        return users;
    }
}