namespace Domain.Models;

public class Post
{
    private Post()
    {
    }

    private Post(Guid id, string title, string description, DateTime createdAt)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedAt = createdAt;
    }

    public static Post Create(string title, string description)
    {
        return new Post(
            Guid.NewGuid(),
            title,
            description,
            DateTime.UtcNow);
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
