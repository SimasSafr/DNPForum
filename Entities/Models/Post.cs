namespace Entities.Models;

public class Post
{
    public Post(string title, string body, string writtenBy, int id)
    {
        Title = title;
        Body = body;
        WrittenBy = writtenBy;
        Id = id;
    }

    public string Title { get; set; }
    public string Body { get; set; }
    public string WrittenBy { get; set; }
    public int Id { get; set; }
}