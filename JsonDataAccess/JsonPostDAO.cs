

using Application.Contracts;
using Entities.Models;

namespace JsonDataAccess;

public class JsonPostDAO : IPostDAO
{

    private JsonContext jsonCont = new ();

    public async Task<ICollection<Post>> ReturnPostList()
    {
        return jsonCont.Forum.Posts;
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        jsonCont.Forum.Posts.Add(post);
        jsonCont.SaveChangesAsync();
        return post;
    }
}