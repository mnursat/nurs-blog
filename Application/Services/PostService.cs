using Application.Interfaces.Repositories;

using Domain.Models;

namespace Application.Services;

public class PostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public void Create(string title, string description)
    {
        var post = Post.Create(title, description);

        _postRepository.Add(post);
    }

    public List<Post> GetAll()
    {
        var posts = _postRepository.GetAll();
        return (List<Post>)posts;
    }
}