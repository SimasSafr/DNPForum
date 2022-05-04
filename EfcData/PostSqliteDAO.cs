using Application.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcData;

public class PostSqliteDAO : IPostDAO
{
    private readonly ForumContext context;
    
    public PostSqliteDAO(ForumContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        EntityEntry<Post> added = await context.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<ICollection<Post>> ReturnPostList()
    {
        ICollection<Post> posts = await context.Posts.ToListAsync();
        return posts;
    }
}