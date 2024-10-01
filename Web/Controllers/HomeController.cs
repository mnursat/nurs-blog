using Application.Services;

using Microsoft.AspNetCore.Mvc;

using Web.DTOs.Posts;
using Web.ViewModels;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly PostService _postService;

    public HomeController(PostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateUser([FromForm] CreatePostViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }

        var request = new CreatePostRequest(
            viewModel.Title,
            viewModel.Description
        );

        _postService.Create(request.Title, request.Description);
        return RedirectToAction(nameof(Index));
    }
}
