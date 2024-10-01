using Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IPostRepository
{
    void Add(Post post);
    IEnumerable<Post> GetAll();
}
