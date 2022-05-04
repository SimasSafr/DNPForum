
using Application.Contracts;
using Entities.Models;

namespace JsonDataAccess;

public class JsonUserDAO : IUserDAO
{

    private JsonContext jsonCont= new JsonContext();
    
    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        User? find = UserList().Find(user => user.UserName.Equals(username));
        return await Task.FromResult(find);
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        return jsonCont.Forum.Users;
    }

    private List<User> UserList()
    {
        List<User> users = jsonCont.Forum.Users.ToList();
        return users;
    }


   
    public async Task<User> CreateUserAsync(User user)
    {
        if (IsValidUsername(user.UserName))
        {
            List<User> temp = UserList();
            temp.Add(user);
            jsonCont.Forum.Users = temp;
            jsonCont.SaveChangesAsync();
            return user;
        }
        else
        {
            throw new Exception("Email invalid");
        }

    }

    bool IsValidUsername(string username)
    {
        var trimmedEmail = username.Trim();

        if (UserList().Any(user => user.UserName.Equals(username)))
        {
            return false;
        }
        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }
        if (username.Equals(jsonCont.Forum.Users.ToString()))
        {
            return false;
        }
        try {
            var addr = new System.Net.Mail.MailAddress(username);
            return addr.Address == trimmedEmail;
        }
        catch {
            return false;
        }
    }
    
   
}