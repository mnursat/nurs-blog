using Application.Interfaces.Repositories;

using Domain.Models;

namespace Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly NursBlogDbContext _context;

    public PostRepository(NursBlogDbContext context)
    {
        _context = context;
    }

    public void Add(Post post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
    }

    public IEnumerable<Post> GetAll()
    {
        return _context.Posts.ToList();
    }
}
