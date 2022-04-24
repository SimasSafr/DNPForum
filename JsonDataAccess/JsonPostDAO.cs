
using Application.Contracts;
using Entities.Models;

namespace JsonDataAccess;

public class JsonPostDAO : IPostDAO
{

    private JsonContext jsonCont = new JsonContext();

    private List<Post> PostList()
    {
        List<Post> posts = jsonCont.Forum.Posts.ToList();
        return posts;
    }

    public async Task<ICollection<Post>> ReturnPostList()
    {
        return  jsonCont.Forum.Posts;
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        if (String.IsNullOrEmpty(post.Title) || String.IsNullOrEmpty(post.Body) || String.IsNullOrEmpty(post.WrittenBy))
        {
            throw new Exception("Please fill in all the fields");
        }
        else
        {
            int id = PostList().Count + 1;

            List<Post> temp = PostList();

            temp.Add(post);

            jsonCont.Forum.Posts = temp;
            jsonCont.SaveChangesAsync();
            return post;
        }
    }
}