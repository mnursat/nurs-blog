using Application.Services;

using Microsoft.AspNetCore.Mvc;

using Web.DTOs.Posts;
using Web.ViewModels;

namespace Web.Controllers;

public class PostController : Controller
{
    private readonly PostService _postService;

    public PostController(PostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var posts = _postService.GetAll();

        var postsViewModel = posts.Select(p =>
            new PostViewModel { Id = p.Id, Title = p.Title, Description = p.Description.Substring(0, 180), CreatedAt = p.CreatedAt});

        return View(postsViewModel.ToList());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] CreatePostViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var request = new CreatePostRequest(
            viewModel.Title,
        viewModel.Description
        );

        _postService.Create(request.Title, request.Description);
        return RedirectToAction(nameof(Index));
    }
}
