using Entities.Models;

namespace Application.Contracts;

public interface IPostDAO
{
    public Task<Post> CreatePostAsync(Post post);
    public Task<ICollection<Post>> ReturnPostList();
}