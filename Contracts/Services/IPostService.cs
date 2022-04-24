using Entities.Models;

namespace Contracts.Services;

public interface IPostService
{
    public Task<ICollection<Post>> GetAllPostsAsync();
    public Task<Post> GetPostByWriterAsync(string writtenBy);
    public Task<Post> AddPostAsync(Post post);
}