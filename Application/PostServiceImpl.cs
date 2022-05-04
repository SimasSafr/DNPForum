using Application.Contracts;
using Contracts.Services;
using Entities.Models;

namespace Application;

public class PostServiceImpl : IPostService
{
    private IPostDAO postDao;

    public PostServiceImpl(IPostDAO postDao) {
        this.postDao = postDao;
    }
    public async Task<ICollection<Post>> GetAllPostsAsync()
    {
        return await postDao.ReturnPostList();
    }

    public async Task<Post> GetPostByWriterAsync(string writtenBy)
    {
        ICollection<Post> post = await postDao.ReturnPostList();
        return post.FirstOrDefault(p => writtenBy.Equals(writtenBy))!; //is wrong
    }

    public async Task<Post> AddPostAsync(Post post)
    {
        return await postDao.CreatePostAsync(post);
    }

    public async Task<Post> GetPostByIdAsync(int id)
    {
        ICollection<Post> post = await postDao.ReturnPostList();
        return post.FirstOrDefault(p => id.Equals(p.Id))!;
    }
}